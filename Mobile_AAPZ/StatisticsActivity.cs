using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Com.Syncfusion.Charts;



namespace Mobile_AAPZ
{
    [Activity(Label = "@string/Statistics", Theme = "@style/AppTheme.NoActionBar")]
    public class StatisticsActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        APIClient apiClient;
        Dictionary<string, double> yearDict;
        Dictionary<string, double> monthDict;
        Dictionary<string, double> weekDict;
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

            SetContentView(Resource.Layout.activity_statistics);

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
            yearDict = await apiClient.GetStatisticsByYearAsync(2019, 2);
            monthDict = await apiClient.GetStatisticsByMonthAsync(2019, 4, 2);
            weekDict = await apiClient.GetAverageStatisticsByWeekAsync(2);

            Button yearButton = FindViewById<Button>(Resource.Id.st_year);
            Button monthButton = FindViewById<Button>(Resource.Id.st_month);
            Button weekButton = FindViewById<Button>(Resource.Id.st_day);

            SfChart chartYear = new SfChart(this);
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Title.Text = "Month";
            chartYear.PrimaryAxis = primaryAxis;
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Appearences";
            secondaryAxis.Maximum = 1;
            chartYear.SecondaryAxis = secondaryAxis;
            ColumnSeries series = new ColumnSeries
            {
                ItemsSource = yearDict,
                XBindingPath = "Key",
                YBindingPath = "Value"
            };
            chartYear.Series.Add(series);

            SfChart chartMonth = new SfChart(this);
            CategoryAxis primaryMonthAxis = new CategoryAxis();
            primaryMonthAxis.Title.Text = "Day";
            chartMonth.PrimaryAxis = primaryMonthAxis;
            NumericalAxis secondaryMonthAxis = new NumericalAxis();
            secondaryMonthAxis.Title.Text = "Appearences";
            secondaryMonthAxis.Maximum = 1;
            chartMonth.SecondaryAxis = secondaryMonthAxis;
            ColumnSeries seriesMonth = new ColumnSeries
            {
                ItemsSource = monthDict,
                XBindingPath = "Key",
                YBindingPath = "Value"
            };
            chartMonth.Series.Add(seriesMonth);

            SfChart chartWeek = new SfChart(this);
            CategoryAxis primaryWeekAxis = new CategoryAxis();
            primaryWeekAxis.Title.Text = "Day";
            chartWeek.PrimaryAxis = primaryWeekAxis;
            NumericalAxis secondaryWeekAxis = new NumericalAxis();
            secondaryWeekAxis.Title.Text = "Appearences";
            secondaryWeekAxis.Maximum = 1;
            chartWeek.SecondaryAxis = secondaryWeekAxis;
            ColumnSeries seriesWeek = new ColumnSeries
            {
                ItemsSource = weekDict,
                XBindingPath = "Key",
                YBindingPath = "Value"
            };
            chartWeek.Series.Add(seriesWeek);


            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.statistics_layout);

            yearButton.Click += (s, arg) =>
            {
                linearLayout.RemoveView(chartMonth);
                linearLayout.RemoveView(chartWeek);
                linearLayout.RemoveView(chartYear);
                linearLayout.AddView(chartYear);
            };
            monthButton.Click += (s, arg) =>
            {
                linearLayout.RemoveView(chartYear);
                linearLayout.RemoveView(chartWeek);
                linearLayout.RemoveView(chartMonth);
                linearLayout.AddView(chartMonth);

            };
            weekButton.Click += (s, arg) =>
            {
                linearLayout.RemoveView(chartWeek);
                linearLayout.RemoveView(chartYear);
                linearLayout.RemoveView(chartMonth);
                linearLayout.AddView(chartWeek);
            };





            //    SfChart weekMonth = new SfChart(this);
            //    CategoryAxis primaryWeekAxis = new CategoryAxis();
            //    primaryWeekAxis.Title.Text = "Day";
            //    weekMonth.PrimaryAxis = primaryWeekAxis;
            //    NumericalAxis secondaryWeekAxis = new NumericalAxis();
            //    secondaryWeekAxis.Title.Text = "Appearences";
            //    secondaryWeekAxis.Maximum = 1;
            //    weekMonth.SecondaryAxis = secondaryWeekAxis;
            //    Dictionary<string, double> weekDict = await apiClient.GetAverageStatisticsByWeekAsync(2);
            //    ColumnSeries weekSeries = new ColumnSeries
            //    {
            //        ItemsSource = weekDict,
            //        XBindingPath = "Key",
            //        YBindingPath = "Value"
            //    };
            //    weekMonth.Series.Add(weekSeries);
            //    linearLayout.AddView(weekMonth);
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