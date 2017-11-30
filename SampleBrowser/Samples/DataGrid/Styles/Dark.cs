#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace SampleBrowser
{
	public class Dark : DataGridStyle
	{
		public Dark ()
		{
		}

        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromRgb (15, 15, 15);
        }

        public override Color GetHeaderForegroundColor()
        {
            return Color.FromRgb (255, 255, 255);
        }

		public override Color GetRecordBackgroundColor ()
		{
			return Color.FromRgb (43, 43, 43);
		}

		public override Color GetRecordForegroundColor ()
		{
			return Color.FromRgb (255, 255, 255);
		}

		public override Color GetSelectionBackgroundColor ()
		{
			return Color.FromRgb (42, 159, 214);
		}

		public override Color GetSelectionForegroundColor ()
		{
			return Color.FromRgb (255, 255, 255);
		}

		public override Color GetCaptionSummaryRowBackgroundColor ()
		{
			return Color.FromRgb (02, 02, 02);
		}

		public override Color GetCaptionSummaryRowForeGroundColor ()
		{
			return Color.FromRgb (255, 255, 255);
		}

		public override Color GetBordercolor ()
		{
			return Color.FromRgb (81, 83, 82);
		}

		public override Color GetAlternatingRowBackgroundColor()
		{
			return Color.FromRgb (25, 25, 25);
		}
	}
}

