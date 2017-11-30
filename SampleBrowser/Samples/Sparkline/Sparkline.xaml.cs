#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
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

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class Sparkline : SamplePage
    {
        public Sparkline()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone)
            {
                Sparkline_Phone sparkline_phone = new Sparkline_Phone();
                this.ContentView = sparkline_phone.getContent();
                this.PropertyView = sparkline_phone.getPropertyView();
            }
            else if(Device.OS == TargetPlatform.Windows || Device.Idiom == TargetIdiom.Tablet)
            {
                Sparkline_Windows sparkline_windows = new Sparkline_Windows();
                this.ContentView = sparkline_windows.getContent();
                this.PropertyView = sparkline_windows.getPropertyView();
            }

        }
    }
}
