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

namespace SampleBrowser
{
	public partial class CalendarLocalization_Default : SamplePage
	{
		double width;
		public CalendarLocalization_Default ()
		{
			InitializeComponent();
			calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.sampleSettings();
		}
		void sampleSettings()
		{
			width = App.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
			this.Padding = new Thickness(-10);
			if (Device.OS == TargetPlatform.Android)
				calendar.HeaderHeight = 50 * (float)(App.Density / 2);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				sampleLayout.Padding = new Thickness(0, 0, 0, 90);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Scale = 0.95;
			}
			localeLabel.WidthRequest = width / 2;
			mainStack.Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50);
			mainStack.Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10);
			localePicker.Items.Add("Chinese");
			localePicker.Items.Add("Spanish");
			localePicker.Items.Add("English");
			localePicker.Items.Add("French");
			localePicker.SelectedIndex = 0;
			localePicker.SelectedIndexChanged += SelectionChangedPicker; ;
		}
		public View getContent()
		{
			return this.ContentView;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}

		void SelectionChangedPicker(object sender, EventArgs e)
		{
			switch (localePicker.SelectedIndex)
			{
				case 0:
					{
						calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
					}
					break;
				case 1:
					{
						calendar.Locale = new System.Globalization.CultureInfo("es-AR");
					}
					break;
				case 2:
					{
						calendar.Locale = new System.Globalization.CultureInfo("en-US");
					}
					break;
				case 3:
					{
						calendar.Locale = new System.Globalization.CultureInfo("fr-CA");
					}
					break;
			}
		}
	}
}
