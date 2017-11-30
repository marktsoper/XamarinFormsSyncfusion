#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class Trackball
    {
        public Trackball()
        {
            InitializeComponent();

			secondaryAxis.MajorTickStyle.TickSize = 0;
			secondaryAxis.AxisLineStyle.StrokeWidth = 0;
			secondaryAxis.Maximum = 50;
			secondaryAxis.Minimum = 25;

			ser1.Color = Color.FromRgb(253, 128, 35);
			ser2.Color = Color.FromRgb(115, 170, 174);
			ser3.Color = Color.FromRgb(195, 192, 91);

			labelDisplayMode.SelectedIndex = 0;
            labelDisplayMode.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;

            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
                labelDisplayMode.WidthRequest = 300;
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(labelDisplayMode.SelectedIndex)
            {
                case 0:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints;
                    break;
                case 1:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.NearestPoint;
                    break;
            }
        }
    }

	public class StringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value.ToString()+"%";
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string Value = value.ToString();
			int result;
			if (Int32.TryParse(Value, out result))
				return result;
			return value;
		}

	}
}
