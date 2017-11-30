#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.SfSchedule.XForms;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class Configurations
    {
		#region Properties and Variables

		PickerExt schedule_view_picker;
		StackLayout configuration_layout;
		Xamarin.Forms.Slider work_start_slider, work_end_slider;

		DayViewSettings day_view_setting;
		WeekViewSettings week_view_setting;
		WorkWeekViewSettings work_week_view_setting;
		MonthViewSettings month_view_setting;
		DatePicker date_picker;
		Switch non_accessible_block_switch;
		Switch black_out_days_switch;
		Switch show_weeknumber_switch;
		Label non_accessible_block;
		Label black_out_days_label;
		Label work_start_hour;
		Label work_start_label;
		Label work_end_hour;
		Label work_end_label;
		Label schedule_view;
		Label week_number;
		Label go_to_date;
		int count = 6;

		#endregion Properties and Variables

		#region Constructor

		public Configurations()
		{
			InitializeComponent();

			if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				grid_layout.WidthRequest = App.ScreenWidth;
				grid_layout.HeightRequest = App.ScreenHeight;
			}
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                Schedule.HeaderHeight = 40;
            }
			if (Device.Idiom == TargetIdiom.Tablet && Device.OS == TargetPlatform.Android)
			{
				Schedule.ViewHeaderHeight = 35;
			}

			InitializingConfigurationSettings();
			CreateConfigurationSettingsLayout();

			DayViewSettings dayViewSettings = new DayViewSettings();
			dayViewSettings.WorkStartHour = 7;
			dayViewSettings.WorkEndHour = 18;
			Schedule.DayViewSettings = dayViewSettings;
		}

		#endregion Contructor

		#region Methods

		#region Initializing ConfigurationSettings

		//Initializing ConfigurationSettings
		private void InitializingConfigurationSettings()
		{
			day_view_setting = new DayViewSettings();
			week_view_setting = new WeekViewSettings();
			work_week_view_setting = new WorkWeekViewSettings();
			month_view_setting = new MonthViewSettings();

			NonAccessibleBlock nonAccessibleBlock = new NonAccessibleBlock();
			nonAccessibleBlock.StartTime = 13;
			nonAccessibleBlock.EndTime = 14;
			nonAccessibleBlock.Text = "Lunch Time";
			day_view_setting.NonAccessibleBlocks.Add(nonAccessibleBlock);
			week_view_setting.NonAccessibleBlocks.Add(nonAccessibleBlock);
			work_week_view_setting.NonAccessibleBlocks.Add(nonAccessibleBlock);
			month_view_setting.ShowWeekNumber = true;

			Schedule.DayViewSettings = day_view_setting;
			Schedule.WeekViewSettings = week_view_setting;
			Schedule.WorkWeekViewSettings = work_week_view_setting;

			month_view_setting.MonthLabelSettings = new MonthLabelSettings();
			Schedule.MonthViewSettings = month_view_setting;

			List<DateTime> black_out_days = new List<DateTime>();

			for (int i = 0; i < count; i++)
			{
				DateTime date = DateTime.Now.Date.AddDays(i);
				black_out_days.Add(date);
			}
		}

		#endregion Initializing ConfigurationSettings

		#region ConfigurationSettingsLayout

		//Creating ConfigurationSettingsLayout
		void CreateConfigurationSettingsLayout()
		{
			configuration_layout = new StackLayout();
			configuration_layout.Padding = 10;

			AddScheduleViewPickerItems();
			schedule_view_picker.SelectedIndexChanged += PickerSelectedIndexChanged;

			//Show WorkStartHour Slider
			StackLayout workstart_layout = new StackLayout();
			workstart_layout.Orientation = StackOrientation.Horizontal;

			AddWorkStartSlider();
			work_start_slider.ValueChanged += WorkStartSliderValueChanged;

			workstart_layout.Children.Add(work_start_hour);
			workstart_layout.Children.Add(work_start_label);
			configuration_layout.Children.Add(workstart_layout);
			configuration_layout.Children.Add(work_start_slider);

			//Show WorkEndHour Slider 
			StackLayout workend_layout = new StackLayout();
			workend_layout.Orientation = StackOrientation.Horizontal;

			AddWorkEndHourSlider();
			work_end_slider.ValueChanged += WorkEndSliderValueChanged;

			workend_layout.Children.Add(work_end_hour);
			workend_layout.Children.Add(work_end_label);
			configuration_layout.Children.Add(workend_layout);
			configuration_layout.Children.Add(work_end_slider);


			// Show Non_Accessible_Block Switch
			StackLayout non_accessible_block_layout = new StackLayout();
			non_accessible_block_layout.Orientation = StackOrientation.Horizontal;

			AddNonAccessibleBlockSwitch();
			non_accessible_block_switch.Toggled += NonAccessibleBlockSwitchToggled;

			StackLayout non_accessible_switch__layout = new StackLayout();
			non_accessible_switch__layout.Orientation = StackOrientation.Horizontal;

			//non_accessible_switch__layout.Children.Add(non_accessible_block_switch);
			//non_accessible_switch__layout.Padding = new Thickness(40, 0, 0, 0);

			non_accessible_block_layout.Children.Add(non_accessible_block);
			non_accessible_block_layout.Children.Add(non_accessible_switch__layout);
			// configuration_layout.Children.Add(non_accessible_block_layout);

			// Show BlackOutDays Switch  
			StackLayout black_out_days_layout = new StackLayout();
			black_out_days_layout.Orientation = StackOrientation.Horizontal;

			AddBlackOutDaysSwitch();
			black_out_days_layout.Children.Add(black_out_days_label);
			black_out_days_layout.Children.Add(black_out_days_switch);
			//configuration_layout.Children.Add(black_out_days_layout);

			//Show week number 
			StackLayout show_week_number_layout = new StackLayout();
			show_week_number_layout.Orientation = StackOrientation.Horizontal;

			AddShowWeekNumber();

			show_week_number_layout.Children.Add(week_number);
			show_week_number_layout.Children.Add(show_weeknumber_switch);
			//configuration_layout.Children.Add(show_week_number_layout);

			// LAYOUTS ALIGNMENT *************************

			// Adding Layouts
			//Show_layout1
			Grid grid;
			if (App.Platform == Platforms.Windows81)
			{
				grid = new Grid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				},
					ColumnDefinitions =
				{

					new ColumnDefinition { Width = 100 },
					new ColumnDefinition { Width = GridLength.Auto },
				}
				};
			}
			else
			{
				grid = new Grid
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				},
					ColumnDefinitions =
				{

					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				}
				};
			}
			grid.Padding = new Thickness(0, 20, 0, 60);
			grid.Children.Add(non_accessible_block, 0, 0);
			grid.Children.Add(black_out_days_label, 0, 1);
			grid.Children.Add(week_number, 0, 2);

			grid.Children.Add(non_accessible_block_switch, 1, 0);
			grid.Children.Add(black_out_days_switch, 1, 1);
			grid.Children.Add(show_weeknumber_switch, 1, 2);



			//             ********************************
			AddGoToDate();

			configuration_layout.Children.Add(go_to_date);

			date_picker = new DatePicker();
			if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				StackLayout go_to_date_layout = new StackLayout();
				go_to_date_layout.Padding = new Thickness(-35, 0, -30, 0);
				date_picker = new DatePicker();
				date_picker.Scale = 0.8;
				date_picker.DateSelected += DatePickerGoToDate;
				go_to_date_layout.Children.Add(date_picker);
				configuration_layout.Children.Add(go_to_date_layout);
			}
			else
			{
				date_picker = new DatePicker();
				date_picker.DateSelected += DatePickerGoToDate;
				configuration_layout.Children.Add(date_picker);
			}

			configuration_layout.Children.Add(schedule_view);
			configuration_layout.Children.Add(schedule_view_picker);

			if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				//  configuration_layout.BackgroundColor = Color.White;
			}
			configuration_layout.Children.Add(grid);

			this.PropertyView = configuration_layout;
		}

		#endregion ConfigurationSettingsLayout

		#region Adding items to Schedule view picker

		//Defining Schedule view settings
		private void AddScheduleViewPickerItems()
		{
			schedule_view = new Label();
			schedule_view.Text = "Select the schedule view";
			schedule_view.FontSize = 15;
			if (Device.OS == TargetPlatform.Android)
				schedule_view.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    schedule_view.TextColor = Color.White;
			else
				schedule_view.TextColor = Color.Black;

			schedule_view_picker = new PickerExt();
			schedule_view_picker.WidthRequest = 500;
			schedule_view_picker.Items.Add("Day View");
			schedule_view_picker.Items.Add("Week View");
			schedule_view_picker.Items.Add("Work Week View");
			schedule_view_picker.Items.Add("Month View");
			schedule_view_picker.SelectedIndex = 0;
		}

		#endregion Adding items to Schedule view picker

		#region Adding WorkStartHour Slider

		//Defining WorkStartHour Slider settings
		private void AddWorkStartSlider()
		{
			work_start_hour = new Label();
			work_start_hour.Text = "Work Start Hour :";
			work_start_hour.FontSize = 15;
			if (Device.OS == TargetPlatform.iOS)
				work_start_hour.TextColor = Color.Black;
			else if (Device.OS == TargetPlatform.Android)
				work_start_hour.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    work_start_hour.TextColor = Color.White;
			else
				work_start_hour.TextColor = Color.Black;

			work_start_label = new Label();
			work_start_label.Text = " 9";
			work_start_label.FontSize = 15;

			work_start_slider = new Xamarin.Forms.Slider();
			work_start_slider.Minimum = 0;
			work_start_slider.Maximum = 24;
			work_start_slider.Value = 9;
		}

		#endregion Adding WorkStartHour Slider

		#region Adding WorkEndhour Slider

		//Defining WorkEndHour Slider settings
		private void AddWorkEndHourSlider()
		{
			work_end_hour = new Label();
			work_end_hour.Text = "Work End Hour :";
			work_end_hour.FontSize = 15;
			if (Device.OS == TargetPlatform.iOS)
				work_end_hour.TextColor = Color.Black;
			else if (Device.OS == TargetPlatform.Android)
				work_end_hour.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    work_end_hour.TextColor = Color.White;
			else
				work_end_hour.TextColor = Color.Black;

			work_end_label = new Label();
			work_end_label.Text = " 18";
			work_end_label.FontSize = 15;

			work_end_slider = new Xamarin.Forms.Slider();
			work_end_slider.Minimum = 0;
			work_end_slider.Maximum = 24;
			work_end_slider.Value = 18;
		}

		#endregion Adding WorkEndhour Slider

		#region Adding NonAccessibleBlock Switch

		//Defining NonAccessibleBlock settings
		private void AddNonAccessibleBlockSwitch()
		{
			non_accessible_block = new Label();
			non_accessible_block.FontSize = 15;
			non_accessible_block.Text = "Show Non-Accessible Blocks";
			if (Device.OS == TargetPlatform.iOS)
				non_accessible_block.TextColor = Color.Black;
			else if (Device.OS == TargetPlatform.Android)
				non_accessible_block.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    non_accessible_block.TextColor = Color.White;
			else
				non_accessible_block.TextColor = Color.Black;

			non_accessible_block_switch = new Switch();
			non_accessible_block_switch.IsToggled = true;
		}

		#endregion Adding NonAccessibleBlock Switch

		#region Adding BlackOutDays Switch

		//Defining BlackOutDays settings
		private void AddBlackOutDaysSwitch()
		{
			black_out_days_switch = new Switch();
			black_out_days_label = new Label();
			black_out_days_label.FontSize = 15;
			black_out_days_label.Text = "Show Blackout Days";
			if (Device.OS == TargetPlatform.iOS)
				black_out_days_label.TextColor = Color.Black;
			else if (Device.OS == TargetPlatform.Android)
				black_out_days_label.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    black_out_days_label.TextColor = Color.White;
			else
				black_out_days_label.TextColor = Color.Black;

			black_out_days_switch.IsToggled = false;
			black_out_days_switch.Toggled += BlackOutDaysSwitchToggled;
		}

		#endregion Adding BlackOutDays Switch

		#region Adding ShowWeekNumber

		//Defining ShowWeekNumber settings
		private void AddShowWeekNumber()
		{
			show_weeknumber_switch = new Switch();
			week_number = new Label();
			week_number.FontSize = 15;
			week_number.Text = "Show Week Number";
			if (Device.OS == TargetPlatform.iOS)
				week_number.TextColor = Color.Black;
			else if (Device.OS == TargetPlatform.Android)
				week_number.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    week_number.TextColor = Color.White;
			else
				week_number.TextColor = Color.Black;

			show_weeknumber_switch.IsToggled = true;
			show_weeknumber_switch.Toggled += ShowWeekNumberSwitchToggled;
		}

		#endregion Adding ShowWeekNumber

		#region Adding GoToDate Picker

		//Defining GoToDateSettings
		private void AddGoToDate()
		{
			go_to_date = new Label();
			go_to_date.Text = "Go To Date";
			go_to_date.FontSize = 15;
			if (Device.OS == TargetPlatform.iOS)
				go_to_date.TextColor = Color.Black;
			else if (Device.OS == TargetPlatform.Android)
				go_to_date.TextColor = Color.Black;
			//else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			//    go_to_date.TextColor = Color.White;
			else
				go_to_date.TextColor = Color.Black;
		}

		#endregion Adding GoToDate Picker

		#endregion Methods

		#region Events


		#region ScheduleView_PickerSelectedIndexChanged

		void PickerSelectedIndexChanged(object sender, EventArgs e)
		{
			switch ((sender as Picker).SelectedIndex)
			{
				case 0:
					Schedule.ScheduleView = ScheduleView.DayView;
					break;
				case 1:
					Schedule.ScheduleView = ScheduleView.WeekView;
					break;
				case 2:
					Schedule.ScheduleView = ScheduleView.WorkWeekView;
					break;
				case 3:
					Schedule.ScheduleView = ScheduleView.MonthView;
					break;
			}
		}

		#endregion ScheduleView_PickerSelectedIndexChanged

		#region NonAccessibleBlockSwitchToggled

		void NonAccessibleBlockSwitchToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				//  Non- accessible block
				NonAccessibleBlocksCollection nonAccessibleBlocksCollection = new NonAccessibleBlocksCollection();
				NonAccessibleBlock non_accessible_block = new NonAccessibleBlock();
				non_accessible_block.StartTime = 13;
				non_accessible_block.EndTime = 14;
				non_accessible_block.Text = "Lunch Break";
				nonAccessibleBlocksCollection.Add(non_accessible_block);
				Schedule.DayViewSettings.NonAccessibleBlocks = nonAccessibleBlocksCollection;
				Schedule.WeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocksCollection;
				Schedule.WorkWeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocksCollection;
			}
			else
			{
				Schedule.DayViewSettings.NonAccessibleBlocks = new NonAccessibleBlocksCollection();
				Schedule.WeekViewSettings.NonAccessibleBlocks = new NonAccessibleBlocksCollection();
				Schedule.WorkWeekViewSettings.NonAccessibleBlocks = new NonAccessibleBlocksCollection();
			}
		}

		#endregion NonAccessibleBlockSwitchToggled

		#region ShowWeekNumberSwitchToggled

		void ShowWeekNumberSwitchToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				month_view_setting.ShowWeekNumber = true;
				Schedule.MonthViewSettings = month_view_setting;
			}
			else
			{
				MonthViewSettings month_view_setting1 = new MonthViewSettings();
				month_view_setting1.ShowWeekNumber = false;
				Schedule.MonthViewSettings = month_view_setting1;
			}
		}

		#endregion ShowWeekNumberSwitchToggled

		#region DatePickerGoToDate

		void DatePickerGoToDate(object sender, DateChangedEventArgs e)
		{
			Schedule.MoveToDate = (e.NewDate);
		}

		#endregion DatePickerGoToDate

		#region BlackOutDaysSwitchToggled

		void BlackOutDaysSwitchToggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				ObservableCollection<DateTime> black_out_days_collection = new ObservableCollection<DateTime>();

				DateTime date = DateTime.Now.Date;
				DateTime date1 = DateTime.Now.Date.AddDays(1);
				DateTime date2 = DateTime.Now.Date.AddDays(2);
				DateTime date3 = DateTime.Now.Date.AddDays(3);
				DateTime date4 = DateTime.Now.Date.AddDays(4);
				DateTime date5 = DateTime.Now.Date.AddDays(5);

				black_out_days_collection.Add(date);
				black_out_days_collection.Add(date1);
				black_out_days_collection.Add(date2);
				black_out_days_collection.Add(date3);
				black_out_days_collection.Add(date4);
				black_out_days_collection.Add(date5);
				MonthViewSettings month_view_setting1 = new MonthViewSettings();
				month_view_setting1.BlackoutDates = black_out_days_collection;
				Schedule.MonthViewSettings = month_view_setting1;
			}
			else
			{
				Schedule.MonthViewSettings = new MonthViewSettings();
				Schedule.MonthViewSettings.BlackoutDates = new ObservableCollection<DateTime>();
			}
		}

		#endregion BlackOutDaysSwitchToggled

		#region WorkStartHourSliderValueChanged

		void WorkStartSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			if (e.NewValue <= work_end_slider.Value)
			{
				Schedule.DayViewSettings.WorkStartHour = (int)e.NewValue;
				Schedule.WorkWeekViewSettings.WorkStartHour = (int)e.NewValue;
				Schedule.WeekViewSettings.WorkStartHour = (int)e.NewValue;

				work_start_label.Text = ((int)e.NewValue).ToString("");
			}
			else
			{
				work_start_slider.Value = work_end_slider.Value;
			}

		}

		#endregion WorkStartHourSliderValueChanged

		#region WorkEndHourSliderValueChanged

		void WorkEndSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			if (e.NewValue >= work_start_slider.Value)
			{
				Schedule.DayViewSettings.WorkEndHour = (int)e.NewValue;
				Schedule.WorkWeekViewSettings.WorkEndHour = (int)e.NewValue;
				Schedule.WeekViewSettings.WorkEndHour = (int)e.NewValue;

				work_end_label.Text = ((int)e.NewValue).ToString("");
			}
			else
			{
				work_end_slider.Value = work_start_slider.Value;
			}


		}

		#endregion WorkEndHourSliderValueChanged

		#endregion Events
	}
}