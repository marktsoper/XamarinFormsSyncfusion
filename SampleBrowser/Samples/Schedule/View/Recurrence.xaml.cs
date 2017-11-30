#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class Recurrence
    {
        public Recurrence()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                grid_layout.HeightRequest = App.ScreenHeight;
                grid_layout.WidthRequest = App.ScreenWidth;
                
            }
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                Schedule.HeaderHeight = 40;
            }

        }


	}
}
