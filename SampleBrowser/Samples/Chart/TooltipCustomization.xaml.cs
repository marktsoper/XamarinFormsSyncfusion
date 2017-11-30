#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
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

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class TooltipCustomization : SamplePage
    {
        public TooltipCustomization()
        {
            InitializeComponent();
            tooltipBehavior.BackgroundColor = Color.FromRgb(193, 39, 45);
            splineSeries.Color = Color.FromRgb(255, 150, 00);
            dataMarker.MarkerColor = Color.FromRgb(250, 0, 0);
        }
    }
}
