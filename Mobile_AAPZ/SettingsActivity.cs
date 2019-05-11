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
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace Mobile_AAPZ
{
    [Activity(Label = "@string/Settings", Theme = "@style/AppTheme.NoActionBar")]
    public class SettingsActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        APIClient apiClient;
        Client client;

        EditText heightEditText;
        TextView heightTextView;
        EditText visionEditText;
        TextView visionTextView;
        EditText tableHeightEditText;
        TextView tableHeightTextView;
        EditText chairHeightEditText;
        TextView chairHeightTextView;
        EditText lightEditText;
        TextView lightTextView;
        EditText temperatureEditText;
        TextView temperatureTextView;
        EditText musicEditText;
        TextView musicTextView;
        EditText drinkEditText;
        TextView drinkTextView;


        protected async override void OnCreate(Bundle savedInstanceState)
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

            SetContentView(Resource.Layout.activity_settings);

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

            FindLayoutControls();
            
            apiClient = new APIClient();
            client = await apiClient.GetClientByIdAsync(0);
            double recomChairValue = await apiClient.CalculateRecommendedChairHeightAsync((int)client.Id);
            double recomTableValue = await apiClient.CalculateRecommendedTableHeightAsync((int)client.Id);

            ManageLayoutData();
            SetControlsClick();

            Button recomTable = FindViewById<Button>(Resource.Id.rec_table);
            recomTable.Click += async (s, arg) => {
                if (client != null)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Recommended table height");
                    alert.SetMessage(((int)recomTableValue).ToString());
                    alert.SetPositiveButton("Apply", async (senderAlert, arg1) =>
                    {
                        client.TableHight = (int)recomTableValue;
                        tableHeightEditText.Text = client.TableHight.ToString();
                        tableHeightEditText.Visibility = ViewStates.Visible;
                    });

                    alert.SetNegativeButton("Close", (senderAlert, arg1) =>
                    {
                        Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            };

            Button recomChair = FindViewById<Button>(Resource.Id.rec_chair);
            recomChair.Click += async (s, arg) => {
                if (client != null)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Recommended chair height");
                    alert.SetMessage(((int)recomChairValue).ToString());
                    alert.SetPositiveButton("Apply", async (senderAlert, arg1) =>
                    {
                        client.ChairHight = (int)recomChairValue;
                        chairHeightEditText.Text = client.ChairHight.ToString();
                        chairHeightEditText.Visibility = ViewStates.Visible;
                    });

                    alert.SetNegativeButton("Close", (senderAlert, arg1) =>
                    {
                        Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                    
                }
            };
           
        }

        public void FindLayoutControls()
        {
            heightEditText = FindViewById<EditText>(Resource.Id.height_edit_text);
            heightTextView = FindViewById<TextView>(Resource.Id.height_text_view);
            visionEditText = FindViewById<EditText>(Resource.Id.vision_edit_text);
            visionTextView = FindViewById<TextView>(Resource.Id.vision_text_view);
            tableHeightEditText = FindViewById<EditText>(Resource.Id.table_height_edit_text);
            tableHeightTextView = FindViewById<TextView>(Resource.Id.table_height_text_view);
            chairHeightEditText = FindViewById<EditText>(Resource.Id.chair_height_edit_text);
            chairHeightTextView = FindViewById<TextView>(Resource.Id.chair_height_text_view);
            lightEditText = FindViewById<EditText>(Resource.Id.light_edit_text);
            lightTextView = FindViewById<TextView>(Resource.Id.light_text_view);
            drinkEditText = FindViewById<EditText>(Resource.Id.drink_edit_text);
            drinkTextView = FindViewById<TextView>(Resource.Id.drink_text_view);
            musicEditText = FindViewById<EditText>(Resource.Id.music_edit_text);
            musicTextView = FindViewById<TextView>(Resource.Id.music_text_view);
            temperatureEditText = FindViewById<EditText>(Resource.Id.temperature_edit_text);
            temperatureTextView = FindViewById<TextView>(Resource.Id.temperature_text_view);

        }

        public void ManageLayoutData()
        {
            heightTextView.Text = "Height: " + client.Hight.ToString();
            heightEditText.Text = client.Hight.ToString();
            visionTextView.Text = "Vision: " + client.Vision.ToString();
            visionEditText.Text = client.Vision.ToString();
            tableHeightTextView.Text = "Table height: " + client.TableHight.ToString();
            tableHeightEditText.Text = client.TableHight.ToString();
            chairHeightTextView.Text = "Chair height: " + client.ChairHight.ToString();
            chairHeightEditText.Text = client.ChairHight.ToString();
            lightTextView.Text = "Light: " + client.Light.ToString();
            lightEditText.Text = client.Light.ToString();
            temperatureTextView.Text = "Temperature: " + client.Temperature.ToString();
            temperatureEditText.Text = client.Temperature.ToString();
            musicTextView.Text = "Music: " + ((client.Music != null) ? client.Music.ToString() : "");
            musicEditText.Text = ((client.Music != null) ? client.Music.ToString() : "");
            drinkTextView.Text = "Drink: " + ((client.Drink != null) ? client.Drink.ToString() : "");
            drinkEditText.Text = ((client.Drink != null) ? client.Drink.ToString() : "");
        }

        public void SetControlsClick()
        {
            heightTextView.Click += (s, arg) =>
            {
                heightEditText.Visibility = (heightEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            visionTextView.Click += (s, arg) =>
            {
                visionEditText.Visibility = (visionEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            tableHeightTextView.Click += (s, arg) =>
            {
                tableHeightEditText.Visibility = (tableHeightEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;        
            };
            chairHeightTextView.Click += (s, arg) =>
            {
                chairHeightEditText.Visibility = (chairHeightEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            lightTextView.Click += (s, arg) =>
            {
                lightEditText.Visibility = (lightEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            temperatureTextView.Click += (s, arg) =>
            {
                temperatureEditText.Visibility = (temperatureEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            musicTextView.Click += (s, arg) =>
            {
                musicEditText.Visibility = (musicEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            drinkTextView.Click += (s, arg) =>
            {
                drinkEditText.Visibility = (drinkEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
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
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public void UpdateClient()
        {
            int clientHight = 0;
            int clientVision = 0;
            int tableHeight = 0;
            int chairHeight = 0;
            int clientLight = 0;
            int clientTemperature = 0;
            if (!int.TryParse(heightEditText.Text, out clientHight) || !int.TryParse(visionEditText.Text, out clientVision)
                || !int.TryParse(tableHeightEditText.Text, out tableHeight) || !int.TryParse(chairHeightEditText.Text, out chairHeight)
                || !int.TryParse(lightEditText.Text, out clientLight) || !int.TryParse(temperatureEditText.Text, out clientTemperature))
            {
                Toast.MakeText(this, "Invalid data", ToastLength.Short).Show();
            }
            else
            {
                client.Hight = clientHight;
                client.Vision = clientVision;
                client.TableHight = tableHeight;
                client.ChairHight = chairHeight;
                client.Light = clientLight;
                client.Temperature = clientTemperature;
                client.Music = musicEditText.Text;
                client.Drink = drinkEditText.Text;
                apiClient.UpdateClientAsync(client);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.menu_save)
            {
                UpdateClient();
                ManageLayoutData();
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

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}
