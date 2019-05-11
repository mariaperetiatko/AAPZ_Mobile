using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace Mobile_AAPZ
{
    [Activity(Label = "@string/Workplace", Theme = "@style/AppTheme.NoActionBar")]
    public class WorkplaceActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        TextView selectedDateTextView;
        Workplace workplace;
        Building building;
        Landlord landlord;
        APIClient apiClient;
        ObservableCollection<WorkplaceOrder> workplaceOrders;
        int workplaceId;
        List<Button> timeTextViews;
        Client client;

        List<TimeSpan> busyTimes;
        List<TimeSpan> orderedTimes;
        DateTime selectetDate;
        TimeSpan selectedTime;
        ObservableCollection<WorkplaceEquipment> workplaceEquipments;

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

            SetContentView(Resource.Layout.activity_workplace);

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
            
            busyTimes = new List<TimeSpan>()
                {
                    new TimeSpan(9, 0, 0),
                    new TimeSpan(9, 30, 0),
                    new TimeSpan(10, 0, 0),
                    new TimeSpan(10, 30, 0),
                    new TimeSpan(11, 0, 0),
                    new TimeSpan(11, 30, 0),
                    new TimeSpan(12, 0, 0),
                    new TimeSpan(12, 30, 0),
                    new TimeSpan(13, 0, 0),
                    new TimeSpan(13, 30, 0),
                    new TimeSpan(14, 0, 0),
                    new TimeSpan(14, 30, 0),
                    new TimeSpan(15, 0, 0),
                    new TimeSpan(15, 30, 0),
                    new TimeSpan(16, 0, 0),
                    new TimeSpan(16, 30, 0),
                    new TimeSpan(17, 0, 0),
                    new TimeSpan(17, 30, 0),
                    new TimeSpan(18, 0, 0),
                    new TimeSpan(18, 30, 0),
                    new TimeSpan(19, 0, 0),
                    new TimeSpan(19, 30, 0),
                    new TimeSpan(20, 0, 0),
                    new TimeSpan(20, 30, 0)
                };
            orderedTimes = new List<TimeSpan>();

            selectedDateTextView = FindViewById<TextView>(Resource.Id.sel_date_text_view);
            
            Button selectDateButton = FindViewById<Button>(Resource.Id.sel_date_button);
            selectDateButton.Click += SelectDateButtonOnClick;
            timeTextViews = new List<Button>();
            workplaceId = int.Parse(prefs.GetString("workplaceId", ""));
            apiClient = new APIClient();
            workplace = await apiClient.GetWorkplaceByIdAsync(workplaceId);
            building = await apiClient.GetBuildingByIdAsync((int)workplace.BuildingId);
            landlord = await apiClient.GetLandlordByIdAsync((int)building.LandlordId);
            client = await apiClient.GetClientByIdAsync(1);
            TextView workplaceNumberTextView = FindViewById<TextView>(Resource.Id.workplace_number_text_view);
            workplaceNumberTextView.Text += workplaceId.ToString();

            TextView addressTextView = FindViewById<TextView>(Resource.Id.address_text_view);
            addressTextView.Text += building.Country + ", " + building.City + ", " + building.Street
                + ", " + building.House + ", " + building.Flat.ToString();

            TextView landlordTextView = FindViewById<TextView>(Resource.Id.landloed_text_view);
            landlordTextView.Text += landlord.FirstName + ", " + landlord.LastName + ", " + landlord.Phone.ToString()
                + ", " + landlord.Email;

            workplaceOrders = await apiClient.GetWorkplaceOrdersListAsync();

            workplaceEquipments = await apiClient.GetWorkplaceEquipmentsListAsync();
            List<WorkplaceEquipment> we = workplaceEquipments.Where(x => x.WorkplaceId == workplaceId).ToList();
            string equipmentString = "";
            foreach(WorkplaceEquipment equipment in we)
            {
                Equipment eq = await apiClient.GetEquipmentByIdAsync((int)(equipment.EquipmentId));
                equipmentString += eq.Name;
            }
            TextView eqTextView = FindViewById<TextView>(Resource.Id.equipment_text_view);
            eqTextView.Text += equipmentString;
        }

        public void ManageSelectdDataButton(DateTime time)
        {
            ClearTextViews();
            orderedTimes.Clear();
            orderedTimes.Add(new TimeSpan(21, 0, 0));
            List<TimeSpan> newDT = new List<TimeSpan>(busyTimes);
            foreach (WorkplaceOrder workplaceOrder in workplaceOrders)
            {
                if (workplaceOrder.WorkplaceId == workplaceId && workplaceOrder.StartTime.Value.Year == time.Year
                && workplaceOrder.StartTime.Value.Month == time.Month && workplaceOrder.StartTime.Value.Day == time.Day)
                {
                    for (int i = newDT.Count - 1; i >= 0; i--)
                    {
                        bool moreCriteria = false;
                        bool lessCriteria = false;

                        if (newDT[i].Hours == workplaceOrder.StartTime.Value.Hour)
                        {
                            moreCriteria = newDT[i].Minutes >= workplaceOrder.StartTime.Value.Minute;
                        }
                        else if (newDT[i].Hours > workplaceOrder.StartTime.Value.Hour)
                        {
                            moreCriteria = true;
                        }

                        if (newDT[i].Hours == workplaceOrder.FinishTime.Value.Hour)
                        {
                            lessCriteria = newDT[i].Minutes < workplaceOrder.FinishTime.Value.Minute;
                        }
                        else if (newDT[i].Hours < workplaceOrder.FinishTime.Value.Hour)
                        {
                            lessCriteria = true;
                        }
                   
                        if (moreCriteria && lessCriteria)
                        {
                            orderedTimes.Add(newDT[i]);
                            newDT.RemoveAt(i);
                        }
                    }
                }
                orderedTimes.Sort();

            }

            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.workplace_layout);

                for (int i = 0; i < newDT.Count; i++)
                {
                    Button textView = new Button(this)
                    {
                        Text = newDT[i].ToString(),
                        Id = i
                    };

                textView.Click += (s, arg) =>
                {
                    TimeSpan start = newDT[textView.Id];
                    selectedTime = start;
                    TimeSpan finish = orderedTimes.FirstOrDefault(x => x > start);

                    PopupMenu menu = new PopupMenu(this, textView);

                    while (!(start.Hours == finish.Hours && start.Minutes == finish.Minutes))
                    {
                        Console.WriteLine((finish - start).ToString());

                        menu.Menu.Add((finish - start).ToString());

                        finish -= new TimeSpan(0, 30, 0);
                    }

                    menu.MenuItemClick += async (s1, arg1) =>
                    {
                        TimeSpan dur = TimeSpan.Parse(arg1.Item.TitleFormatted.ToString());

                        WorkplaceOrder workplaceOrder = new WorkplaceOrder();
                        workplaceOrder.ClientId = client.Id;
                        workplaceOrder.WorkplaceId = workplaceId;
                        workplaceOrder.StartTime = new DateTime(selectetDate.Year, selectetDate.Month, selectetDate.Day,
                            selectedTime.Hours, selectedTime.Minutes, selectedTime.Seconds);
                        TimeSpan fin = dur + selectedTime;
                        workplaceOrder.FinishTime = new DateTime(selectetDate.Year, selectetDate.Month, selectetDate.Day,
                           fin.Hours, fin.Minutes, fin.Seconds);
                        workplaceOrder = await apiClient.CreateWorkplaceOrderAsync(workplaceOrder);

                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Creation");
                        alert.SetMessage("Created, Total cost: " + workplaceOrder.SumToPay.ToString());
                        alert.SetPositiveButton("OK", async (senderAlert, arg2) =>
                        {
                            int amound = dur.Hours * 2 + ((dur.Minutes == 30) ? 1 : 0);
                            for (int j = textView.Id; j < (textView.Id + amound); j++)
                            {
                                linearLayout.RemoveView(timeTextViews[j]);
                                orderedTimes.Add(newDT[j]);
                            }
                            orderedTimes.Sort();
                        });
                        Dialog dialog = alert.Create();
                        dialog.Show();
                    };
                    menu.Show();

                };

                    timeTextViews.Add(textView);
                    linearLayout.AddView(textView);
                }
            
        }

        public void ClearTextViews()
        {
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.workplace_layout);
            foreach (TextView item in timeTextViews)
            {
                linearLayout.RemoveView(item);
            }
            timeTextViews.Clear();
        }

        void SelectDateButtonOnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                selectetDate = time;
                selectedDateTextView.Text = time.Date.ToString("yyyy-MM-dd");
                ManageSelectdDataButton(time);
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
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

public class DatePickerFragment : DialogFragment,
    DatePickerDialog.IOnDateSetListener
{
    // TAG can be any string of your choice.  
    public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
    // Initialize this value to prevent NullReferenceExceptions.  
    Action<DateTime> _dateSelectedHandler = delegate { };
    public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
    {
        DatePickerFragment frag = new DatePickerFragment();
        frag._dateSelectedHandler = onDateSelected;
        return frag;
    }
    public override Dialog OnCreateDialog(Bundle savedInstanceState)
    {
        DateTime currently = DateTime.Now;
        DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month, currently.Day);
        return dialog;
    }
    public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
    {
        // Note: monthOfYear is a value between 0 and 11, not 1 and 12!  
        DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
        //Log.Debug(TAG, selectedDate.ToLongDateString());
        _dateSelectedHandler(selectedDate);
    }
}
