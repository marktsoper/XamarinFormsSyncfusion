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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using SampleBrowser.Droid;

namespace SampleBrowser.Droid
{
    public class CustomTooltipBehavior : ChartTooltipBehavior
    {
        Context context;
        public CustomTooltipBehavior(Context con)
        {
            context = con;
        }

        protected override void DrawTooltip(Canvas canvas, TooltipView tooltipView)
        {
            base.DrawTooltip(canvas, tooltipView);
            Bitmap bitmap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.grain);
            bitmap = Bitmap.CreateScaledBitmap(bitmap, (int)(40 * context.Resources.DisplayMetrics.Density), (int)(33.33f * context.Resources.DisplayMetrics.Density), false);
            canvas.DrawBitmap(bitmap, (tooltipView.LabelRect.Left + 3.5f) * context.Resources.DisplayMetrics.Density, (tooltipView.LabelRect.Top + 3.5f) * context.Resources.DisplayMetrics.Density, null);
        }
    }
}