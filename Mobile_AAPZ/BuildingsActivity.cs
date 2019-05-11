using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Mobile_AAPZ
{
    [Activity(Label = "BuildingsActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class BuildingsActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        ObservableCollection<Building> buildings;
        ObservableCollection<Workplace> workplaces;
        List<Workplace> workplacesList;

        APIClient apiClient;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            ISharedPreferencesEditor editor = prefs.Edit();
            if (prefs.GetString("locale", "") == "")
            {
                editor.PutString("locale", "en");
                editor.Apply();
            }
            string loc = prefs.GetString("locale", "");
            var locale = new Java.Util.Locale(loc);

            Java.Util.Locale.Default = locale;
            var config = new Android.Content.Res.Configuration { Locale = locale };
#pragma warning disable CS0618 // Type or member is obsolete
            BaseContext.Resources.UpdateConfiguration(config, metrics: BaseContext.Resources.DisplayMetrics);
#pragma warning restore CS0618 // Type or member is obsolete
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_buildings);

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

            apiClient = new APIClient();
            buildings = await apiClient.GetBuildingsListAsync();
            workplaces = await apiClient.GetWorkplacesListAsync();
            workplacesList = workplaces.ToList();

            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.lay_build);

            //foreach (Building building in buildings)
            //{
            //    TextView buildTextView = new TextView(this);
            //    buildTextView.Text = "Address: " + building.Country + ", " + building.City + ", " + building.Street + ", "
            //        + building.House.ToString() + ", " + building.Flat.ToString();
            //    Landlord landlord = await apiClient.GetLandlordByIdAsync((int)building.LandlordId);
            //    buildTextView.Text += "\nLandlord: " + landlord.FirstName + " " + landlord.LastName
            //        + "\n Phone: " + landlord.Phone.ToString() + "\n Email: " + landlord.Email;
            //    linearLayout.AddView(buildTextView);
            //}

            Button search = FindViewById<Button>(Resource.Id.search_button);
            EditText editCountry = FindViewById<EditText>(Resource.Id.country_edit_text);
            EditText editCity = FindViewById<EditText>(Resource.Id.city_edit_text);
            EditText editStreet = FindViewById<EditText>(Resource.Id.street_edit_text);
            EditText editHouse = FindViewById<EditText>(Resource.Id.house_edit_text);
            EditText editFlat = FindViewById<EditText>(Resource.Id.flat_edit_text);
            int flat = 0;
            List<Building> resultList = new List<Building>(buildings).ToList();

            search.Click += async (s, arg) =>
                {
                    linearLayout.RemoveAllViews();
                    if (editCountry.Text != "")
                    {
                        resultList = resultList.Where(x => x.Country == editCountry.Text).ToList();
                    }
                    if (editCity.Text != "")
                    {
                        resultList = resultList.Where(x => x.City == editCity.Text).ToList();
                    }
                    if (editStreet.Text != "")
                    {
                        resultList = resultList.Where(x => x.Street == editStreet.Text).ToList();
                    }
                    if (editHouse.Text != "")
                    {
                        resultList = resultList.Where(x => x.House == editHouse.Text).ToList();
                    }
                    if (int.TryParse(editFlat.Text, out flat) && flat > 0)
                    {
                        resultList = resultList.Where(x => x.Flat == flat).ToList();
                    }

                    foreach (var item in resultList)
                    {
                        TextView buildTextView = new TextView(this);
                        buildTextView.Text = "Address: " + item.Country + ", " + item.City + ", " + item.Street + ", "
                            + item.House.ToString() + ", " + item.Flat.ToString();
                        Landlord lord = await apiClient.GetLandlordByIdAsync((int)item.LandlordId);
                        buildTextView.Text += "\nLandlord: " + lord.FirstName + " " + lord.LastName
                            + "\n Phone: " + lord.Phone.ToString() + "\n Email: " + lord.Email;
                        buildTextView.Id = (int)item.Id;
                        linearLayout.AddView(buildTextView);

                        buildTextView.Click += (s1, arg1) =>
                        {
                            List<Workplace> wokpl = workplacesList.Where(x => x.BuildingId == buildTextView.Id).ToList();
                            PopupMenu menu = new PopupMenu(this, buildTextView);
                            foreach (var work in wokpl)
                            {
                                menu.Menu.Add(work.Mark.ToString() + "," + work.Id.ToString());
                                
                            }

                            menu.MenuItemClick += async (s2, arg2) =>
                            {
                                string workplaceString = arg2.Item.TitleFormatted.ToString();
                                int workplaceId = int.Parse(workplaceString.Split(',')[1]);
                                ISharedPreferences prefs1 = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                                ISharedPreferencesEditor editor1 = prefs1.Edit();

                                editor1.PutString("workplaceId", workplaceId.ToString());
                                editor1.Apply();

                                var intent = new Intent(this, typeof(WorkplaceActivity));
                                StartActivity(intent);
                            };
                                menu.Show();


                        };
                    }
                };
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
            MenuInflater.Inflate(Resource.Menu.menu_common, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.menu_common_lang)
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

                return true;
            }
            else if (id == Resource.Id.menu_main_logout)
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                return true;
            }

            return base.OnOptionsItemSelected(item);

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
                var intent = new Intent(this, typeof(WorkplaceParametersActivity));
                StartActivity(intent);
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

            }
            else if (id == Resource.Id.nav_landlords)
            {

            }
            else if (id == Resource.Id.nav_logout)
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}
