using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Newtonsoft.Json;

namespace Mobile_AAPZ
{
    [Activity(Label = "@string/Workplace_parameters", Theme = "@style/AppTheme.NoActionBar")]
    public class WorkplaceParametersActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        SearchingViewModel searchingViewModel;
        EditText radiusEditText;
        EditText costEditText;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            ISharedPreferences prefs1 = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            ISharedPreferencesEditor editor1 = prefs1.Edit();
            if (prefs1.GetString("locale", "") == "")
            {
                editor1.PutString("locale", "en");
                editor1.Apply();
            }
            string loc = prefs1.GetString("locale", "");
            var locale = new Java.Util.Locale(loc);

            Java.Util.Locale.Default = locale;
            var config = new Android.Content.Res.Configuration { Locale = locale };
#pragma warning disable CS0618 // Type or member is obsolete
            BaseContext.Resources.UpdateConfiguration(config, metrics: BaseContext.Resources.DisplayMetrics);
#pragma warning restore CS0618 // Type or member is obsolete
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_workplace_parameters);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            APIClient apiClient = new APIClient();
            ObservableCollection<Equipment> equipmentList = await apiClient.GetEquipmentsListAsync();
            
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            if(prefs.GetString("searchingViewModel", "") == "")
            {
                searchingViewModel = new SearchingViewModel();
                searchingViewModel.X = 33;
                searchingViewModel.Y = 33;
                searchingViewModel.Radius = 500;
                searchingViewModel.WantedCost = 500;
                searchingViewModel.SearchingModel = new ObservableCollection<SearchingModel>();
                for(int i = 0; i < equipmentList.Count; i++)
                {
                    SearchingModel searchingModel = new SearchingModel();
                    searchingModel.EquipmentId = equipmentList[i].Id;
                    searchingModel.Importancy = 0;
                    searchingViewModel.SearchingModel.Add(searchingModel);
                }
            }
            else
            {
                searchingViewModel = JsonConvert.DeserializeObject<SearchingViewModel>(prefs.GetString("searchingViewModel", ""));
                searchingViewModel.Radius = (searchingViewModel.Radius == null) ? 500 : searchingViewModel.Radius;
                searchingViewModel.WantedCost = (searchingViewModel.WantedCost == null) ? 500 : searchingViewModel.WantedCost;

            }

            radiusEditText = FindViewById<EditText>(Resource.Id.radius_edit_text);
            radiusEditText.Text = searchingViewModel.Radius.ToString();
            costEditText = FindViewById<EditText>(Resource.Id.cost_edit_text);
            costEditText.Text = searchingViewModel.WantedCost.ToString();

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.worplace_p);
            LinearLayout.LayoutParams layoutParamsLayout = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            layoutParamsLayout.Gravity = GravityFlags.Left;

            for (int i = 0; i < equipmentList.Count; i++)
            {
                LinearLayout newLayout = new LinearLayout(this)
                {
                    LayoutParameters = layoutParamsLayout,
                    Orientation = Orientation.Horizontal
                };
                TextView textView = new TextView(this)
                {
                    Text = equipmentList[i].Name
                    
                };
                textView.SetTextAppearance(Resource.Style.TextAppearance_AppCompat_Medium);
                RatingBar ratingBar = new RatingBar(this)
                {
                    NumStars = 5,
                    Rating = (int)(searchingViewModel.SearchingModel[i].Importancy * 5),
                    LayoutParameters = layoutParams,
                    StepSize = 1,
                    Id = i
                };

                TextView cross = new TextView(this)
                {
                    LayoutParameters = layoutParams,
                    Id = i + 100
                };
                cross.SetCompoundDrawablesWithIntrinsicBounds(0, 0, Resource.Mipmap.cancel, 0);                

                linearLayout.AddView(textView);
                newLayout.AddView(ratingBar);
                newLayout.AddView(cross);

                linearLayout.AddView(newLayout);

                ratingBar.RatingBarChange += (o, e) => {
                    Toast.MakeText(this, "New Rating: " + ratingBar.Rating.ToString(), ToastLength.Short).Show();
                    searchingViewModel.SearchingModel[ratingBar.Id].Importancy = Math.Round(ratingBar.Rating * 0.2, 2);
                };
                cross.Click += (o, e) => {
                    searchingViewModel.SearchingModel[ratingBar.Id].Importancy = 0;
                    ratingBar.FindViewById<RatingBar>(cross.Id - 100).Rating = 0;
                };
            }
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.menu_save)
            {
                int radiusValue = 0;
                int costValue = 0;
                if (radiusEditText.Text == "" || costEditText.Text == "" || !int.TryParse(radiusEditText.Text, out radiusValue)
                    || !int.TryParse(costEditText.Text, out costValue) || radiusValue <= 0 || costValue <= 0)
                {
                    Toast.MakeText(this, "Invalid data", ToastLength.Short).Show();
                }
                else
                {
                    searchingViewModel.Radius = radiusValue;
                    searchingViewModel.WantedCost = costValue;

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    ISharedPreferencesEditor editor = prefs.Edit();
                    string json = JsonConvert.SerializeObject(searchingViewModel);
                    editor.PutString("searchingViewModel", json);
                    editor.Apply();
                }
                return true;
            }
            else if (id == Resource.Id.menu_main_logout)
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                return true;
            }
            else if (id == Resource.Id.menu_main_lang)
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                ISharedPreferencesEditor editor = prefs.Edit();
                if (prefs.GetString("locale", "") == "en")
                {
                    editor.PutString("locale", "uk");

                }
                else
                {
                    editor.PutString("locale", "en");
                }
                editor.Apply();

                string loc = prefs.GetString("locale", "");
                var locale = new Java.Util.Locale(loc);
                var config = new Android.Content.Res.Configuration { Locale = locale };
#pragma warning disable CS0618 // Type or member is obsolete
                BaseContext.Resources.UpdateConfiguration(config, metrics: BaseContext.Resources.DisplayMetrics);
#pragma warning restore CS0618 // Type or member is obsolete

                //ava.Util.Locale.Default = locale;
                this.Recreate();
            }

                return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                var intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);

            }
            else if (id == Resource.Id.nav_settings)
            {
                var intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_workplace_parameters)
            {

            }
            else if (id == Resource.Id.nav_map_search)
            {
                var intent = new Intent(this, typeof(MapSearchActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_scheduler)
            {
                var intent = new Intent(this, typeof(SchedulerActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_statistics)
            {
                var intent = new Intent(this, typeof(StatisticsActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_buildings)
            {
                var intent = new Intent(this, typeof(BuildingsActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_landlords)
            {

            }
            else if (id == Resource.Id.nav_logout)
            {

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}
