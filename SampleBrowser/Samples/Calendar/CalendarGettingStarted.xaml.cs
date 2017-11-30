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
	public partial class CalendarGettingStarted : SamplePage
	{
		double width;
	
		public CalendarGettingStarted ()
		{
			InitializeComponent();
			this.sampleSettings();
		}

		void sampleSettings()
		{
			width = App.ScreenWidth;
			if (Device.OS == TargetPlatform.Android)
				cal.HeaderHeight = 50 * (float)(App.Density / 2);
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}

			if (Device.OS == TargetPlatform.iOS)
			{
				cal.HeaderHeight = 40;
				if (Device.Idiom == TargetIdiom.Tablet)
					this.Padding = new Thickness(-20);
				sampleLayout.Padding = new Thickness(0, 0, 0, 90);
			}
			this.Padding = new Thickness(-10);
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Scale = 0.95;
			}
		}
	}
}

