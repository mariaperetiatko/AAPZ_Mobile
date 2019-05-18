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
    [Activity(Label = "AdminClientsActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class AdminClientsActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        APIClient apiClient;
        ObservableCollection<Client> clients;

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

            SetContentView(Resource.Layout.activity_admin_clients);

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
            clients = await apiClient.GetClientsListAsync();
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.admin_clients_layout);

            Android.Graphics.Drawables.Drawable icon = Resources.GetDrawable(Resource.Mipmap.ic_action_content_create); 
            foreach (Client client in clients)
            {
                TextView textView = new TextView(this)
                {
                    Text = client.FirstName + " " + client.LastName,
                    Id = (int)client.Id
                };
                textView.SetCompoundDrawablesWithIntrinsicBounds(null, null, icon, null);
                textView.Click += (s, arg) =>
                {

                };
                linearLayout.AddView(textView);
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

                return true;
            }
            else if (id == Resource.Id.menu_main_logout)
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                return true;
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

            if (id == Resource.Id.nav_clients)
            {


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
