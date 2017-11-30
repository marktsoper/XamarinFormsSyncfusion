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

namespace SampleBrowser
{
    public partial class Localization 
    {
       
        public Localization()
        {
            InitializeComponent();

			WeekViewSettings weekviewsettings = new WeekViewSettings();
			weekviewsettings.WorkStartHour = 7;
			weekviewsettings.WorkEndHour = 18;
			Schedule.WeekViewSettings = weekviewsettings;
			//weekviewsettings.VerticalLineColor = Color.Blue;
			//weekviewsettings.TimeSlotColor = Color.Red;
			//weekviewsettings.TimeSlotBorderColor = Color.Black;

			//Schedule.TimeInterval = 120;
			//Schedule.TimeIntervalHeight = 200;

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

		}
	}
}
