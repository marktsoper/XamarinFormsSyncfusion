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
using System.Collections.ObjectModel;
using Syncfusion.SfGauge.XForms;

namespace SampleBrowser
{
    public partial class LinearGauge : SamplePage
    {
        public LinearGauge()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows)
            {
                LinearGauge_Default autocomplete = new LinearGauge_Default();
                this.ContentView = autocomplete.getContent();


            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                LinearGauge_Tablet autocompleteTab = new LinearGauge_Tablet();
                this.ContentView = autocompleteTab.getContent();
            }
        }
    }
}
