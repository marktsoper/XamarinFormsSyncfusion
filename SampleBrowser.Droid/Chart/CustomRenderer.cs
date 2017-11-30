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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms.Droid;
using Com.Syncfusion.Charts;
using Native = Com.Syncfusion.Charts;
using Java.Util;
using SampleBrowser;

[assembly: ExportRenderer(typeof(CustomChart), typeof(SampleBrowser.Droid.CustomRenderer))]

namespace SampleBrowser.Droid
{
    class CustomRenderer : SfChartRenderer
    {
        Syncfusion.SfChart.XForms.SfChart chart;
        Native.ChartTooltipBehavior nativeTooltipBehavior;
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Syncfusion.SfChart.XForms.SfChart> e)
        {
            base.OnElementChanged(e);

            chart = e.NewElement as Syncfusion.SfChart.XForms.SfChart;

            var nativeControl = Control;
            nativeControl.Behaviors.Remove(0);
            nativeTooltipBehavior = new CustomTooltipBehavior(Control.Context);
            nativeControl.Behaviors.Add(nativeTooltipBehavior);
            nativeControl.TooltipCreated += sfChart_TooltipCreated;
        }

        private void sfChart_TooltipCreated(object sender, SfChart.TooltipCreatedEventArgs e)
        {
            nativeTooltipBehavior.MarginLeft = 7;
            nativeTooltipBehavior.MarginTop = 7;
            nativeTooltipBehavior.MarginRight = 7;
            nativeTooltipBehavior.MarginBottom = 7;
            nativeTooltipBehavior.BackgroundColor = Android.Graphics.Color.Argb(255, 193, 39, 45);
            nativeTooltipBehavior.TextColor = Android.Graphics.Color.White;
            nativeTooltipBehavior.StrokeWidth = 1f;

            e.P1.Label= ".             " + e.P1.ChartDataPoint.GetX() + "    \n .            " + e.P1.ChartDataPoint.GetY();
        }
       

    }
}