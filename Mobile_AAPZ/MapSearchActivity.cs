using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Collections.ObjectModel;
using Android;
using Android.Preferences;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Newtonsoft.Json;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace Mobile_AAPZ
{
    [Activity(Label = "@string/Map_search", Theme = "@style/AppTheme.NoActionBar")]
    public class MapSearchActivity : AppCompatActivity, IOnMapReadyCallback, NavigationView.IOnNavigationItemSelectedListener
    {
        SearchingViewModel searchingViewModel;
        ObservableCollection<FindedWorkplace> findedWorkplaces;
        APIClient apiClient;
        Dictionary<int, List<Workplace>> Markers;
        Dictionary<string, KeyValuePair<Building, List<Workplace>>> CompositeMarkers;

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
            SetContentView(Resource.Layout.activity_map_search);

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

            Markers = new Dictionary<int, List<Workplace>>();

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            searchingViewModel = JsonConvert.DeserializeObject<SearchingViewModel>(prefs.GetString("searchingViewModel", ""));
            apiClient = new APIClient();
            findedWorkplaces = await apiClient.SearcForWorcplacesAsync(searchingViewModel);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.frag);
            mapFragment.GetMapAsync(this);
        }

        private async void  PerformMarkers(GoogleMap map)
        {
            Markers.Clear();
            CompositeMarkers = new Dictionary<string, KeyValuePair<Building, List<Workplace>>>();
            map.InfoWindowClick += MapOnInfoWindowClick;

            for (int i = 0; i < this.findedWorkplaces.Count; i++)
            {
                Workplace workplace = await apiClient.GetWorkplaceByIdAsync((int)findedWorkplaces[i].WorkplaceId);
                Building building = await apiClient.GetBuildingByIdAsync((int)workplace.BuildingId);

                if (!Markers.ContainsKey((int)building.Id))
                {
                    Markers[(int)building.Id] = new List<Workplace>();
                }
                Markers[(int)building.Id].Add(workplace);
            }
            foreach (var item in Markers)
            {
                Building building = await apiClient.GetBuildingByIdAsync(item.Key);
                MarkerOptions markerOptions = new MarkerOptions();
                markerOptions.SetPosition(new LatLng((double)building.X, (double)building.Y));
                
                string title = building.Country + ", " + building.Country + ", " + building.Street + ", "
                    + building.House.ToString() + ", " + building.Flat.ToString();
                foreach (Workplace workpl in item.Value)
                {
                    title += "\nNum: " + workpl.Id.ToString() + " Cost: " + workpl.Cost.ToString();
                }
                markerOptions.SetTitle(title);

                var image = BitmapDescriptorFactory.FromResource(Resource.Mipmap.workplace);
                markerOptions.SetIcon(image);
                KeyValuePair<Building, List<Workplace>> pair = new KeyValuePair<Building, List<Workplace>>(building, item.Value);
                Marker marker = map.AddMarker(markerOptions);
                CompositeMarkers.Add(marker.Id, pair);
                marker.ShowInfoWindow();
            }
            
        }

        public void OnMapReady(GoogleMap map)
        {
            map.UiSettings.ZoomControlsEnabled = true;
            map.UiSettings.CompassEnabled = true;
            LatLng location = new LatLng(50, 36);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);
            PerformMarkers(map);
        }

        private void MapOnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            Marker myMarker = e.Marker;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            ISharedPreferencesEditor editor = prefs.Edit();
            KeyValuePair<Building, List<Workplace>> buildingInstance = CompositeMarkers[myMarker.Id];
            TextView markerMenu = FindViewById<TextView>(Resource.Id.marker_menu);
            PopupMenu menu = new PopupMenu(this, markerMenu);
            
            foreach (Workplace workplace in buildingInstance.Value)
            {
                FindedWorkplace finded = findedWorkplaces.FirstOrDefault(x => x.WorkplaceId == workplace.Id);
                menu.Menu.Add("Workplace number:" + workplace.Id.ToString() + ",\nWorkplace cost: " + workplace.Cost.ToString()
                    + ",\nAppropriation: " + finded.AppropriationPercentage.ToString() + ",\nCost approp: " + finded.CostColor
                    + ", Address: " + buildingInstance.Key.Country + ", " + buildingInstance.Key.City + ", "
                    + buildingInstance.Key.Street + ", " + buildingInstance.Key.House.ToString() + ", " + buildingInstance.Key.Flat.ToString());   
            }
            menu.MenuItemClick += (s1, arg1) =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Workplace");
                alert.SetMessage(arg1.Item.TitleFormatted.ToString());
                alert.SetPositiveButton("Visit", async (senderAlert, arg) =>
                {
                    string workplaceString = arg1.Item.TitleFormatted.ToString();
                    string[] workplaceStringArr = workplaceString.Split(':', ',');
                    int workplaceId = int.Parse(workplaceString.Split(':', ',')[1]);

                    ISharedPreferences prefs1 = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
                    ISharedPreferencesEditor editor1 = prefs1.Edit();
                   
                    editor1.PutString("workplaceId", workplaceId.ToString());
                    editor1.Apply();
                    
                    var intent = new Intent(this, typeof(WorkplaceActivity));
                    StartActivity(intent);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, arg) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();


            
            };

            menu.DismissEvent += (s2, arg2) =>
            {
                Console.WriteLine("menu dismissed");
            };
            menu.Show();
            //editor.PutString("restaurant", Markers[myMarker.Id].ToString());
            //editor.Apply();

            //var intent = new Intent(this, typeof(RestaurantActivity));
            //StartActivity(intent);
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
            if (id == Resource.Id.menu_save)
            {
                return true;
            }
            else if (id == Resource.Id.menu_main_logout)
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                return true;
            }
            else if (id == Resource.Id.menu_common_lang)
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

                var intent = new Intent(this, typeof(WorkplaceParametersActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_map_search)
            {

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
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}