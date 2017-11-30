#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser
{
	public partial class Customization
	{
		ScheduleAppointmentCollection scheduleAppointmentCollection;
		ScheduleAppointment scheduleAppointment, scheduleAppointment1;

		PickerExt schedule_view_picker;
		StackLayout scheduleView_layout;
		Label schedule_view;

		public Customization()
		{
			InitializeComponent();

			scheduleAppointment = new ScheduleAppointment();
			scheduleAppointment.Subject = "Family";
			scheduleAppointment.StartTime = DateTime.Now.Date.AddHours(10);
			scheduleAppointment.EndTime = DateTime.Now.Date.AddHours(12);
			scheduleAppointment.Color = (Color.FromHex("#FFD80073"));

			scheduleAppointment1 = new ScheduleAppointment();
			scheduleAppointment1.Subject = "CheckUp";
			scheduleAppointment1.StartTime = DateTime.Now.Date.AddDays(1).AddHours(9);
			scheduleAppointment1.EndTime = DateTime.Now.Date.AddDays(1).AddHours(11);
			scheduleAppointment1.Color = Color.FromHex("#FFA2C139");

			scheduleAppointmentCollection = new ScheduleAppointmentCollection();
			scheduleAppointmentCollection.Add(scheduleAppointment);
			scheduleAppointmentCollection.Add(scheduleAppointment1);
			Schedule.DataSource = scheduleAppointmentCollection;


            if (Device.OS != TargetPlatform.Windows && Device.OS != TargetPlatform.WinPhone)
            {
                Schedule.HeaderHeight = 0;
                Schedule.ViewHeaderHeight = 0;

                //On AppointmentLoaded 
                Schedule.OnAppointmentLoadedEvent += Schedule_OnAppointmentLoadedEvent;
                //On MonthCellLoaded
                Schedule.OnMonthCellLoadedEvent += Schedule_OnMonthCellLoadedEvent;
            }
            else
            {
                if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Desktop)
                {
                    Schedule.HeaderHeight = 0;
                }
            }
          
			//ViewHeaderStyle viewheaderstyle = new ViewHeaderStyle();
			//viewheaderstyle.BackgroundColor = Color.Black;

			//Schedule.HeaderStyle.TextColor = Color.Yellow;
			//Schedule.HeaderStyle.BackgroundColor = Color.Black;
			//Schedule.ViewHeaderStyle.DayTextColor = Color.Yellow;
			//Schedule.ViewHeaderStyle.BackgroundColor = Color.Black;

		
			if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				grid_layout.WidthRequest = App.ScreenWidth;
				grid_layout.HeightRequest = App.ScreenHeight;
			}
            if (App.Platform == Platforms.Windows81 || App.Platform == Platforms.WindowsPhone81)
            {
                header_layout.IsVisible = false;
            }
			if (Device.Idiom == TargetIdiom.Tablet && Device.OS == TargetPlatform.iOS)
			{
				grid_layout.RowDefinitions = new RowDefinitionCollection()
				{
					new RowDefinition { Height = App.ScreenHeight*0.05 },
					new RowDefinition { Height = App.ScreenHeight*0.95 },
				};
			}
            Schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
			Schedule.OnMonthCellLoadedEvent += Schedule_OnMonthCellLoadedEvent;

			month_label.Text = DateTime.Today.Date.ToString("dd, MMMM, yyyy");

			CreateScheduleViewLayout();
			DayViewSettings dayViewSettings = new DayViewSettings();
			dayViewSettings.WorkStartHour = 7;
			dayViewSettings.WorkEndHour = 18;
			Schedule.DayViewSettings = dayViewSettings;
		}


		void Schedule_OnAppointmentLoadedEvent(object sender, AppointmentLoadedEventArgs args)
		{

			Button button = new Button();
			button.TextColor = Color.White;
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                if (args.appointment.Subject == "Family")
                {
                    button.BackgroundColor = (Color.FromHex("#FFD80073"));
                    button.Text = "Jeni's B'Day Celebration";

                    button.Image = "family.png";
                }

                else if (args.appointment.Subject == "CheckUp")
                {
                    button.BackgroundColor = Color.FromHex("#FFA2C139");
                    button.Text = "Check Up";
                    button.Image = "Hospital.png";
                }

                args.view = button;
            }
		}

		void Schedule_OnMonthCellLoadedEvent(object sender, MonthCellLoadedEventArgs args)
		{

			string day_Name = args.date.ToString("dddd");

			//if (args.isToday)
			//{
			//	args.monthViewCellStyle.TextColor = Color.FromHex("#EEC72B");
			//	args.monthViewCellStyle.BackgroundColor = Color.Black;
			//}
			//else if (args.isPreviousMonth)
			//{
			//	args.monthViewCellStyle.TextColor = Color.White;
			//}
			//else if (args.isNextMonth)
			//{
			//	args.monthViewCellStyle.TextColor = Color.White;
			//}
			//else if (args.isCurrentMonth)
			//{
			//	args.monthViewCellStyle.TextColor = Color.Black;
			//}

			//if (((day_Name == "Saturday") || (day_Name == "Sunday")) && args.isCurrentMonth)
			//{
			//	args.monthViewCellStyle.TextColor = Color.FromHex("#EEC72B");
			//}

		}
		void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs args)
		{
			List<DateTime> datelist = new List<DateTime>();
			datelist = (args.visibleDates);

			foreach (var item in datelist)
			{
				month_label.Text = item.Date.ToString("dd, MMMM, yyyy");
			}
		}

		void CreateScheduleViewLayout()
		{
			scheduleView_layout = new StackLayout();
			scheduleView_layout.Padding = 10;

			AddScheduleViewPickerItems();
			schedule_view_picker.SelectedIndexChanged += Schedule_View_Picker_SelectedIndexChanged;

			scheduleView_layout.Children.Add(schedule_view);
			scheduleView_layout.Children.Add(schedule_view_picker);

			//this.PropertyView = scheduleView_layout;
		}
		private void AddScheduleViewPickerItems()
		{
			schedule_view = new Label();
			schedule_view.Text = "Select the schedule view";
			schedule_view.FontSize = 15;

			schedule_view_picker = new PickerExt();
			schedule_view_picker.WidthRequest = 500;
			schedule_view_picker.Items.Add("Day View");
			schedule_view_picker.Items.Add("Month View");
			schedule_view_picker.SelectedIndex = 0;

		}
		void Schedule_View_Picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch ((sender as Picker).SelectedIndex)
			{
				case 0:
					Schedule.ScheduleView = ScheduleView.DayView;
					break;
				case 1:
					Schedule.ScheduleView = ScheduleView.MonthView;
					break;
			}
		}

	}
}

