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
    [Activity(Label = "@string/Home", Theme = "@style/AppTheme.NoActionBar")]
    public class HomeActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        APIClient apiClient;
        Client client;
        EditText firstNameEditText;
        TextView firstNameTextView;
        EditText lastNameEditText;
        TextView lastNameTextView;
        EditText birthdayEditText;
        TextView birthdayTextView;
        EditText passportNumberEditText;
        TextView passportNumberTextView;
        EditText phoneEditText;
        TextView phoneTextView;
        EditText emailEditText;
        TextView emailTextView;

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

            SetContentView(Resource.Layout.activity_home);

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
            client = await apiClient.GetClientByIdAsync(0);
            FindLayoutControls();
            ManageLayoutData();
            SetControlsClick();
        }

        public void FindLayoutControls()
        {
            firstNameEditText = FindViewById<EditText>(Resource.Id.first_name_edit_text);
            firstNameTextView = FindViewById<TextView>(Resource.Id.first_name_text_view);
            lastNameEditText = FindViewById<EditText>(Resource.Id.last_name_edit_text);
            lastNameTextView = FindViewById<TextView>(Resource.Id.last_name_text_view);
            birthdayEditText = FindViewById<EditText>(Resource.Id.birthday_edit_text);
            birthdayTextView = FindViewById<TextView>(Resource.Id.birthday_text_view);
            passportNumberEditText = FindViewById<EditText>(Resource.Id.passport_number_edit_text);
            passportNumberTextView = FindViewById<TextView>(Resource.Id.passport_number_text_view);
            phoneEditText = FindViewById<EditText>(Resource.Id.phone_edit_text);
            phoneTextView = FindViewById<TextView>(Resource.Id.phone_text_view);
            emailEditText = FindViewById<EditText>(Resource.Id.email_edit_text);
            emailTextView = FindViewById<TextView>(Resource.Id.email_text_view);
        }

        public void ManageLayoutData()
        {
            firstNameTextView.Text = Resources.GetText(Resource.String.First_name)  + " " + client.FirstName;
            firstNameEditText.Text = client.FirstName;
            lastNameTextView.Text = "Last name: " + client.LastName;
            lastNameEditText.Text = client.LastName;
            birthdayTextView.Text = "Birthday: " + ((DateTime)client.Birthday).ToString("dd/MM/yyyy");
            birthdayEditText.Text = ((DateTime)client.Birthday).ToString("dd/MM/yyyy");
            passportNumberTextView.Text = "Passport number: " + client.PassportNumber.ToString();
            passportNumberEditText.Text = client.PassportNumber.ToString();
            phoneTextView.Text = "Phone " + client.Phone.ToString();
            phoneEditText.Text = client.Phone.ToString();
            emailTextView.Text = "Email: " + client.Email.ToString();
            emailEditText.Text = client.Email.ToString();
        }

        public void SetControlsClick()
        {
            firstNameTextView.Click += (s, arg) =>
            {
                firstNameEditText.Visibility = (firstNameEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            lastNameTextView.Click += (s, arg) =>
            {
                lastNameEditText.Visibility = (lastNameEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            birthdayTextView.Click += (s, arg) =>
            {
                birthdayEditText.Visibility = (birthdayEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            passportNumberTextView.Click += (s, arg) =>
            {
                passportNumberEditText.Visibility = (passportNumberEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            phoneTextView.Click += (s, arg) =>
            {
                phoneEditText.Visibility = (phoneEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
            };
            emailTextView.Click += (s, arg) =>
            {
                emailEditText.Visibility = (emailEditText.Visibility == ViewStates.Visible) ? ViewStates.Invisible : ViewStates.Visible;
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
            DateTime birthdayValue = new DateTime();
            long passportNumberValue = 0;
            long phoneValue = 0;
            string regex = @"(^[a-z]+)(\.[a-z]+)?@[a-z]{2}";
            if (firstNameEditText.Text == "" || lastNameEditText.Text == "" || !DateTime.TryParse(birthdayEditText.Text, out birthdayValue)
                || !long.TryParse(passportNumberEditText.Text, out passportNumberValue) || !long.TryParse(phoneEditText.Text, out phoneValue)
                || !Regex.IsMatch(emailEditText.Text, regex, RegexOptions.IgnoreCase))
            {
                Toast.MakeText(this, "Invalid data", ToastLength.Short).Show();
            }
            else
            {
                client.FirstName = firstNameEditText.Text;
                client.LastName = lastNameEditText.Text;
                client.Birthday = birthdayValue;
                client.PassportNumber = passportNumberValue;
                client.Phone = phoneValue;
                client.Email = emailEditText.Text;

                apiClient.UpdateClientAsync(client);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.menu_save)
            {                
                ManageLayoutData();
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

            if (id == Resource.Id.nav_home)
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
