#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;

namespace SampleBrowser
{
	public partial class Configuration_Default : SamplePage
	{
		double width;
		public Configuration_Default ()
		{
			InitializeComponent ();
			monthViewSettings();
			eventsInitialization();
		}
		void eventsInitialization()
		{
			calendar.OnMonthCellLoaded += (object sender, MonthCell args) =>
			 {
				 DateTime dTime = args.Date;
				 string s = dTime.DayOfWeek.ToString();
				 if (s.Equals("Sunday", StringComparison.CurrentCultureIgnoreCase) || s.Equals("Saturday", StringComparison.CurrentCultureIgnoreCase))
				 {
					 args.TextColor = Color.FromHex("#0990e9");
				 }
			 };

			selectionModePicker.Items.Add("SingleSelection");
			selectionModePicker.Items.Add("MultiSelection");
			selectionModePicker.SelectedIndex = 0;
			selectionModePicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			 {
				 switch (selectionModePicker.SelectedIndex)
				 {
					 case 0:
						 {

							 calendar.SelectionMode = SelectionMode.SingleSelection;
						 }
						 break;
					 case 1:
						 {
							 calendar.SelectionMode = SelectionMode.MultiSelection;
						 }
						 break;

				 }
			 };
			minDatePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 calendar.MinDate = e.NewDate;
			 };
			maxDatePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 calendar.MaxDate = e.NewDate;
			 };
		}
		void monthViewSettings()
		{
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.HeaderTextColor = Color.White;
			monthSettings.HeaderBackgroundColor = Color.FromRgb(61, 61, 61);
			monthSettings.DayHeaderTextColor = Color.White;
			monthSettings.DayHeaderBackgroundColor = Color.FromRgb(61, 61, 61);
			monthSettings.DateSelectionColor = Color.FromRgb(161, 161, 161);
			calendar.MonthViewSettings = monthSettings;
		}
		void sampleSettings()
		{
			width = App.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
			if (Device.OS == TargetPlatform.Android)
				calendar.HeaderHeight = 50 * (float)(App.Density / 2);
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Scale = 0.95;
			}
			mainStack.Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50);
			mainStack.Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				sampleLayout.Padding = new Thickness(0, 0, 0, 90);
			}
			this.Padding = new Thickness(-10);
			selectionModeLabel.WidthRequest = width / 2;
		}
		public View getContent()
		{
			return this.ContentView;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}
	}
}

