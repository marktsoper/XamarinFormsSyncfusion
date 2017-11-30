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
	public partial class BlackoutDates : SamplePage
	{
		List<DateTime> black_dates;
		public BlackoutDates ()
		{
			InitializeComponent();
			this.setBlackOutDates();
			this.sampleSettings();
		}
		void sampleSettings()
		{
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
		}
		void setBlackOutDates()
		{
			black_dates = new List<DateTime>();
			for (int i = 0; i < 5; i++)
			{
				DateTime date = DateTime.Now.Date.AddDays(i + 7);
				black_dates.Add(date);
			}
			calendar.BlackoutDates = black_dates;
		}
		public View getContent()
		{
			return this.ContentView;
		}
	}
}

