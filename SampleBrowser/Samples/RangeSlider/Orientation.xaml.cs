#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfRangeSlider.XForms;

namespace SampleBrowser
{
	public partial class Orientation : SamplePage
	{
		public Orientation()
		{
			InitializeComponent();

			hertzLabel.HorizontalTextAlignment = TextAlignment.Center;
			decibelLabel.HorizontalTextAlignment = TextAlignment.Center;
			hertzLabel1.HorizontalTextAlignment = TextAlignment.Center;
			decibelLabel1.HorizontalTextAlignment = TextAlignment.Center;
			hertzLabel2.HorizontalTextAlignment = TextAlignment.Center;
			decibelLabel2.HorizontalTextAlignment = TextAlignment.Center;
			DeviceChanges();
		}

		void DeviceChanges()
		{ 
		if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
			{



			}
			else
			{
				hertzLabel.FontSize = 20;
				hertzLabel.Text = "60Hz";
				hertzLabel.HeightRequest = 24;
				hertzLabel.VerticalTextAlignment = TextAlignment.Center;
				hertzLabel.TextColor = Color.FromRgb(109, 109, 114);
				hertzLabel.HorizontalTextAlignment = TextAlignment.Center;

				hertzLabel1.FontSize = 20;
				hertzLabel1.Text = "170Hz";
				hertzLabel1.HeightRequest = 24;
				hertzLabel1.VerticalTextAlignment = TextAlignment.Center;
				hertzLabel1.TextColor = Color.FromRgb(109, 109, 114);
				hertzLabel1.HorizontalTextAlignment = TextAlignment.Center;

				hertzLabel2.FontSize = 20;
				hertzLabel2.Text = "310Hz";
				hertzLabel2.HeightRequest = 24;
				hertzLabel2.VerticalTextAlignment = TextAlignment.Center;
				hertzLabel2.TextColor = Color.FromRgb(109, 109, 114);
				hertzLabel2.HorizontalTextAlignment = TextAlignment.Center;

				decibelLabel.FontSize = 12;
				decibelLabel.Text = "-2.2db";
				decibelLabel.HeightRequest = 30;
				decibelLabel.VerticalTextAlignment = TextAlignment.Start;
				decibelLabel.TextColor = Color.FromRgb(57, 181, 247);
				decibelLabel.HorizontalTextAlignment = TextAlignment.Center;

				decibelLabel1.FontSize = 12;
				decibelLabel1.Text = "4.7db";
				decibelLabel1.HeightRequest = 30;
				decibelLabel1.VerticalTextAlignment = TextAlignment.Start;
				decibelLabel1.TextColor = Color.FromRgb(57, 181, 247);
				decibelLabel1.HorizontalTextAlignment = TextAlignment.Center;

				decibelLabel2.FontSize = 12;
				decibelLabel2.Text = "-6db";
				decibelLabel2.HeightRequest = 30;
				decibelLabel2.VerticalTextAlignment = TextAlignment.Start;
				decibelLabel2.TextColor = Color.FromRgb(57, 181, 247);
				decibelLabel2.HorizontalTextAlignment = TextAlignment.Center;

			}

			if (Device.OS == TargetPlatform.iOS)
			{
				if (Device.Idiom == TargetIdiom.Phone)
				{
					sfRangeSlider1.WidthRequest = 90;
					sfRangeSlider2.WidthRequest = 90;
					sfRangeSlider3.WidthRequest = 90;
					sfRangeSlider1.HeightRequest = 300;
					sfRangeSlider2.HeightRequest = 300;
					sfRangeSlider3.HeightRequest = 300;
					sfRangeSlider1.KnobColor = Color.White;
					sfRangeSlider2.KnobColor = Color.White;
					sfRangeSlider3.KnobColor = Color.White;
					MainRangeSlider.VerticalOptions = LayoutOptions.FillAndExpand;
				}
				else if (Device.Idiom == TargetIdiom.Tablet)
				{
					sfRangeSlider1.WidthRequest = 90;
					sfRangeSlider2.WidthRequest = 90;
					sfRangeSlider3.WidthRequest = 90;
					sfRangeSlider1.HeightRequest = 600;
					sfRangeSlider2.HeightRequest = 600;
					sfRangeSlider3.HeightRequest = 600;
					sfRangeSlider1.KnobColor = Color.White;
					sfRangeSlider2.KnobColor = Color.White;
					sfRangeSlider3.KnobColor = Color.White;
					MainRangeSlider.VerticalOptions = LayoutOptions.FillAndExpand;
				}
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				sfRangeSlider1.WidthRequest = 120;
				sfRangeSlider2.WidthRequest = 120;
				sfRangeSlider3.WidthRequest = 120;
				sfRangeSlider1.HeightRequest = 600;
				sfRangeSlider2.HeightRequest = 600;
				sfRangeSlider3.HeightRequest = 600;
				sfRangeSlider1.KnobColor = Color.Gray;
				sfRangeSlider2.KnobColor = Color.Gray;
				sfRangeSlider3.KnobColor = Color.Gray;
				sfRangeSlider1.TrackSelectionColor = Color.Gray;
				sfRangeSlider2.TrackSelectionColor = Color.Gray;
				sfRangeSlider3.TrackSelectionColor = Color.Gray;
			}
			else if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
			{

				sfRangeSlider1.TrackSelectionColor = sfRangeSlider2.TrackSelectionColor = sfRangeSlider3.TrackSelectionColor = Color.Gray;
				sfRangeSlider1.TrackColor = sfRangeSlider2.TrackColor = sfRangeSlider3.TrackColor = Color.Gray;
			}

			sfRangeSlider1.ValueChanging += (object sender, ValueEventArgs e) =>
			{
				double f = Math.Round(e.Value, 1);

				decibelLabel.Text = -1 * f + "db";
			};
			sfRangeSlider2.ValueChanging += (object sender, ValueEventArgs e) =>
			{
				double f = Math.Round(e.Value, 1);

				decibelLabel1.Text = -1 * f + "db";
			};
			sfRangeSlider3.ValueChanging += (object sender, ValueEventArgs e) =>
			{
				double f = Math.Round(e.Value, 1);

				decibelLabel2.Text = -1 * f + "db";
			};
			if ((Device.Idiom == TargetIdiom.Tablet) && (Device.OS != TargetPlatform.iOS))
			{
				MainRangeSlider.HorizontalOptions = LayoutOptions.Center;
				MainRangeSlider.Padding = new Thickness(10, 40, 0, 0);
				FirstSlider.Padding = new Thickness(10, 40, 40, 0);
				SecondSlider.Padding = new Thickness(10, 40, 40, 0);
				ThirdSlider.Padding = new Thickness(10, 40, 40, 0);

			}
			else if (Device.OS != TargetPlatform.iOS)
			{
				MainRangeSlider.HorizontalOptions = LayoutOptions.Center;
				MainRangeSlider.Padding = new Thickness(0, 20, 0, 0);
				FirstSlider.Padding = new Thickness(0, 20, 40, 0);
				SecondSlider.Padding = new Thickness(0, 20, 40, 0);
				ThirdSlider.Padding = new Thickness(0, 20, 40, 0);

			}
		}
		public View getContent()
		{
			return this.ContentView;
		}
	}
}
