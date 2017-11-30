#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public partial class Schedule_View
    {
		void Schedule_VisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs args)
		{
			List<DateTime> datelist = new List<DateTime>();
			datelist = (args.visibleDates);
			scheduleview_list.IsVisible = false;
		
			var item = datelist[0];
				if (Schedule.ScheduleView == ScheduleView.DayView)
				{
				item = datelist[0];
					Month_Button.Text = item.Date.ToString("MMMM, yyyy");
				}
			else if (Schedule.ScheduleView == ScheduleView.WeekView)
				{
				item = datelist[datelist.Count/2];
					Month_Button.Text = item.Date.ToString("MMMM, yyyy");
				}
			else if (Schedule.ScheduleView == ScheduleView.WorkWeekView)
				{
				item = datelist[datelist.Count / 2];
					Month_Button.Text = item.Date.ToString("MMMM, yyyy");
				}
				else 
				{
				item = datelist[datelist.Count / 2];
					Month_Button.Text = item.Date.ToString("MMMM, yyyy");
				}

			if (args.visibleDates.Count > 7)
			{
				moveToDate = args.visibleDates[8];
			}
			else {
				moveToDate = args.visibleDates[0];
			}
		}

		private int indexOfAppointment = 0;
		private bool isNewAppointment = false;
		private DateTime moveToDate = DateTime.Now;

		#region Constructor

		public Schedule_View()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                grid_layout.WidthRequest = App.ScreenWidth;
                grid_layout.HeightRequest = App.ScreenHeight;
            }
			if (Device.Idiom == TargetIdiom.Tablet && Device.OS == TargetPlatform.iOS)
			{
				grid_layout.RowDefinitions = new RowDefinitionCollection()
				{
					new RowDefinition { Height = App.ScreenHeight*0.05 },
					new RowDefinition { Height = App.ScreenHeight*0.95 },
				};
			}
			if (Device.Idiom == TargetIdiom.Tablet && Device.OS == TargetPlatform.Android)
			{
				Schedule.ViewHeaderHeight = 35;

				grid_layout.RowDefinitions = new RowDefinitionCollection()
				{
					new RowDefinition { Height = App.ScreenHeight*0.05 },
					new RowDefinition { Height = App.ScreenHeight*0.95 },
				};
			}


			HookEvents(); 
			scheduleview_list.ItemsSource = Enum.GetValues(typeof(ScheduleView));
			scheduleview_list.SelectedItem = 0;
			DayViewSettings dayViewSettings = new DayViewSettings();
			dayViewSettings.WorkStartHour = 7;
			dayViewSettings.WorkEndHour = 18;
			Schedule.DayViewSettings = dayViewSettings;
            if (Device.OS != TargetPlatform.Windows && Device.OS != TargetPlatform.WinPhone)
            {
                Editor_Button.Image = "editor.png";
                scheduleView_Button.Image = "scheduleview.png";
            }
            else
            {
                Editor_Button.Image = (FileImageSource)ImageSource.FromFile("editor.png");
                scheduleView_Button.Image = (FileImageSource)ImageSource.FromFile("scheduleview.png");
            }
            
            Month_Button.Text = DateTime.Today.Date.ToString("MMMM, yyyy");
            if (Device.OS != TargetPlatform.Windows && Device.OS != TargetPlatform.WinPhone)
            {
                Schedule.HeaderHeight = 0;
            }
            else
            {
                if (App.Platform == Platforms.UWP)
                {
                    Schedule.HeaderHeight = 0;
                }
            }

            editor.AppointmentModified += Editor_AppointmentModified;;

			if (App.Platform == Platforms.WindowsPhone81)
			{
				grid_layout.HeightRequest = App.ScreenHeight;
				grid_layout.WidthRequest = App.ScreenWidth;
			}

			if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
				editor.IsVisible = false;

            if (App.Platform == Platforms.Windows81 || App.Platform == Platforms.WindowsPhone81)
            {
                header_layout.IsVisible = false;
            }

        }

		#endregion Constructor

		#region Methods and Events

		private void HookEvents()
		{
			Schedule.ScheduleCellTapped += Schedule_ScheduleCellTapped;
			Schedule.VisibleDatesChangedEvent += Schedule_VisibleDatesChangedEvent;
			scheduleView_Button.Clicked += ScheduleView_Button_Clicked; 
			Editor_Button.Clicked += Editor_Button_Clicked;
			//movetoDate_Button.Clicked += MovetoDate_Button_Clicked;
			scheduleview_list.ItemSelected += Scheduleview_List_ItemSelected;
		}
       
		#region ScheduleView ButtonClicked

		void ScheduleView_Button_Clicked(object sender, EventArgs e)
		{
			visibilityCheck(true);
		}

		#endregion ScheduleView ButtonClicked

		#region Scheduleview_List_ItemSelected

		void Scheduleview_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem is ScheduleView)
			{
				Schedule.ScheduleView = (ScheduleView)(e.SelectedItem);
			}
			(sender as ListView).IsVisible = false;
		}

		#endregion Scheduleview_List_ItemSelected

		#region MovetoDate_Button_Clicked

		void MovetoDate_Button_Clicked(object sender, EventArgs e)
		{
			scheduleview_list.IsVisible = false;
			//Schedule.MoveToDate = DateTime.Now.Date;
			//DependencyService.Get<IDateNavigation>().Backward();
			//Schedule.NavigateTo(moveToDate);
		}

		#endregion MovetoDate_Button_Clicked

		#region visibilityCheck

		private void visibilityCheck(bool clicked)
		{
			if (clicked)
			{
				scheduleview_list.IsVisible = true;
			}
			else
			{
				scheduleview_list.IsVisible = false;
			}
		}

		#endregion visibilityCheck

		#region Editor_AppointmentModified

		void Editor_AppointmentModified(object sender, SampleBrowser.ScheduleAppointmentModifiedEventArgs e)
		{
			Schedule.IsVisible = true;

			if (e.IsModified)
			{
				if (isNewAppointment)
				{
					(Schedule.DataSource as ScheduleAppointmentCollection).Add(e.Appointment);
				}
				else
				{
					(Schedule.DataSource as ScheduleAppointmentCollection).RemoveAt(indexOfAppointment);
					(Schedule.DataSource as ScheduleAppointmentCollection).Insert(indexOfAppointment, e.Appointment);
				}
			}
		}

		#endregion Editor_AppointmentModified

		#region Schedule_ScheduleCellTapped

		void Schedule_ScheduleCellTapped(object sender, ScheduleTappedEventArgs args)
		{
			scheduleview_list.IsVisible = false;
			if (Schedule.ScheduleView == ScheduleView.MonthView)
			{;
				Schedule.ScheduleView = ScheduleView.DayView;
				scheduleview_list.SelectedItem = 0;
				//Schedule.NavigateTo(args.datetime);
			
			}
			else
			{
				Schedule.IsVisible = false;
				editor.IsVisible = true;
				if (args.selectedAppointment != null)
				{
					ScheduleAppointmentCollection appointment = new ScheduleAppointmentCollection();
					appointment = (ScheduleAppointmentCollection)Schedule.DataSource;
					indexOfAppointment = appointment.IndexOf((ScheduleAppointment)args.selectedAppointment);
					editor.OpenEditor((ScheduleAppointment)args.selectedAppointment, args.datetime);
					isNewAppointment = false;
				}
				else
				{
					//create Apppointmentt
					editor.OpenEditor(null, args.datetime);
					isNewAppointment = true;
				}
			}
		}
		#endregion Schedule_ScheduleCellTapped

		void Editor_Button_Clicked(object sender, EventArgs e)
		{
			scheduleview_list.IsVisible = false;
			Schedule.IsVisible = false;
			editor.IsVisible = true;

			editor.OpenEditor(null, DateTime.Today);
			isNewAppointment = true;
		}

		#endregion Methods and Events
	}
}

