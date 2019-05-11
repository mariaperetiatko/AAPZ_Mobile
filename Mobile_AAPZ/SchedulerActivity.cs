using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Schedule;
using System.Collections.ObjectModel;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Java.Util;
using Android.Graphics;
using Com.Syncfusion.Schedule.Enums;
using System.Globalization;
using Calendar = Java.Util.Calendar;
using ActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Android.Preferences;

namespace Mobile_AAPZ
{
    [Activity(Label = "@string/Scheduler", Theme = "@style/AppTheme.NoActionBar")]
    public class SchedulerActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        SfSchedule schedule;
        ScheduleAppointmentCollection Orders;
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "location_notification";
        internal static readonly string COUNT_KEY = "count";
        string count;
        List<string> colorCollection;
        APIClient apiClient;
        ObservableCollection<Scheduler> schedulerCollection;
        List<Scheduler> schedulerList;
        DateTime minDateTime;

        protected override async void OnCreate(Bundle bundle)
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
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_sceduler);

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
            schedulerCollection = await apiClient.GetScheduleAsync(1);
            schedulerList = schedulerCollection.OrderBy(x => x.Start_date).ToList();

            CreateNotificationChannel();

            schedule = new SfSchedule(this);
            CreateAppointments();
            schedule.ItemsSource = Orders;
            schedule.ScheduleView = ScheduleView.WeekView;
            schedule.CellTapped += schedule_ScheduleCellTapped;
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.scheduler_p);
            linearLayout.AddView(schedule);
            PushNotif();
        }

        public void PushNotif()
        {
            var valuesForActivity = new Bundle();
            count = minDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            valuesForActivity.PutString(COUNT_KEY, count);

            var resultIntent = new Intent(this, typeof(SecondActivity));

            resultIntent.PutExtras(valuesForActivity);

            var stackBuilder = TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SecondActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            var resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            var builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                          .SetAutoCancel(true)
                          .SetContentIntent(resultPendingIntent)
                          .SetContentTitle("Button Clicked")
                          .SetSmallIcon(Resource.Mipmap.notification) 
                          .SetContentText($" {count} "); 

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());
        }
        void schedule_ScheduleCellTapped(object sender, CellTappedEventArgs args)
        {
            var appointment = args.ScheduleAppointment;
            if (appointment != null)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Confirm delete");
                alert.SetMessage(appointment.Subject);
                alert.SetPositiveButton("Delete", async (senderAlert, arg) =>
                {
                    await apiClient.DeleteWorkplaceOrderAsync((int)appointment.RecurrenceId);
                    Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
                    Orders.Remove(appointment);
                    schedule.ItemsSource = Orders;
                    SetContentView(schedule);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, arg) =>
                {
                    Toast.MakeText(this, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }


        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var name = Resources.GetString(Resource.String.channel_name);
            var description = GetString(Resource.String.channel_description);
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

  
        private void CreateColorCollection()
        {
            colorCollection = new List<string>();
            colorCollection.Add("#117EB4");
            colorCollection.Add("#B4112E");
            colorCollection.Add("#C44343");
            colorCollection.Add("#11B45E");
            colorCollection.Add("#43BEC4");
            colorCollection.Add("#B4112E");
            colorCollection.Add("#C44343");
            colorCollection.Add("#117EB4");
            colorCollection.Add("#C4435A");
            colorCollection.Add("#DF5348");
            colorCollection.Add("#43c484");
            colorCollection.Add("#11B49B");
            colorCollection.Add("#C44378");
            colorCollection.Add("#DF8D48");
            colorCollection.Add("#11B45E");
            colorCollection.Add("#43BEC4");
        }

        private void CreateAppointments()
        {
            Orders = new ScheduleAppointmentCollection();
            CreateColorCollection();
            Calendar calendar = Calendar.Instance;
            Calendar DateFrom = Calendar.Instance;
            DateFrom.Add(CalendarField.Date, -10);
            Calendar DateTo = Calendar.Instance;
            DateTo.Add(CalendarField.Date, 10);
            Calendar dateRangeStart = Calendar.Instance;
            dateRangeStart.Add(CalendarField.Date, -3);
            Calendar dateRangeEnd = Calendar.Instance;
            dateRangeEnd.Add(CalendarField.Date, 3);
            
            for(int index = 0; index < schedulerList.Count; index++)
            {              
                ScheduleAppointment order = new ScheduleAppointment();
                Java.Util.Calendar startTimeCalendar = Java.Util.Calendar.Instance;
               
                CultureInfo provider = CultureInfo.InvariantCulture;

                DateTime startDateTime = DateTime.ParseExact(schedulerList[index].Start_date, "yyyy-MM-dd HH:mm:ss", provider);
                DateTime endDateTime = DateTime.ParseExact(schedulerList[index].End_date, "yyyy-MM-dd HH:mm:ss", provider);

                if (startDateTime >= DateTime.Now && startDateTime != endDateTime)
                {
                    if (Orders.Count == 0)
                    {
                        minDateTime = startDateTime;
                    }
                    else
                    {
                        minDateTime = (minDateTime < startDateTime) ? minDateTime : startDateTime;
                    }
                    startTimeCalendar.Set(startDateTime.Year, startDateTime.Month - 1, startDateTime.Day, startDateTime.Hour, startDateTime.Minute);

                    order.StartTime = startTimeCalendar;

                    Calendar endTimeCalendar = Calendar.Instance;
                    endTimeCalendar.Set(endDateTime.Year, endDateTime.Month - 1, endDateTime.Day, endDateTime.Hour, endDateTime.Minute);
                    order.EndTime = endTimeCalendar;
                    order.Color = Color.ParseColor(colorCollection[index % colorCollection.Count]);
                    order.Subject = schedulerList[index].Text;
                    order.RecurrenceId = int.Parse(schedulerList[index].Id);
                    Orders.Add(order);
                }
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
                var intent = new Intent(this, typeof(MapSearchActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_scheduler)
            {
               
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
