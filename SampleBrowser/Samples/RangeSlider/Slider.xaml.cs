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
	public partial class Slider: SamplePage
	{
		Label opacityLabel1, sliderLabel;
		public Slider ()
		{
			InitializeComponent ();
			mountImg.Source = ImageSource.FromFile ("mount.jpg");

			DeviceChanges();
		}

		void DeviceChanges()
		{ 
			sfRangeSlider1.ValueChanging += (object sender, ValueEventArgs e) =>
			 {
				 mountImg.Opacity = (double)(e.Value / 100);
			 };

			opacityLabel1 = new Label()
			{
				Text = "  Opacity",
				HeightRequest = 40,
				VerticalTextAlignment = TextAlignment.End,
			};

			if (Device.OS == TargetPlatform.Android && Device.Idiom == TargetIdiom.Tablet)
			{

				opacityLabel.FontSize = 20;
			}

			if (Device.OS == TargetPlatform.iOS)
			{
				sfRangeSlider1.KnobColor = Color.White;
				if (Device.Idiom == TargetIdiom.Tablet)
				{
					mountImg.WidthRequest = 500;
					mountImg.HeightRequest = 500;
					sfRangeSlider1.WidthRequest = 500;
					opacityLabel1.HeightRequest = 30;
					sampleLayout.Padding = new Thickness(120, 20);
				}
				sliderLabel = new Label()
				{
					Text = "\n Slider",
					HeightRequest = 20,
					VerticalTextAlignment = TextAlignment.Start,
					HorizontalTextAlignment = TextAlignment.Start

				};
			}
			else {
				sliderLabel = new Label()
				{
					Text = "Slider",
					HeightRequest = 30,
					VerticalTextAlignment = TextAlignment.Start,
					HorizontalTextAlignment = TextAlignment.Center
				};
			}
			sliderLabel.FontAttributes = FontAttributes.Bold;
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sfRangeSlider1.BackgroundColor = Color.Gray;
				sfRangeSlider1.HeightRequest = 130;

				mountImg.WidthRequest = 400;
				mountImg.HeightRequest = 400;
				mountImg.Aspect = Aspect.AspectFit;
				mountImg.Source = ImageSource.FromFile("mount.jpg");
			}
			if (Device.OS == TargetPlatform.Windows)
			{
				sfRangeSlider1.HeightRequest = 150;
				mountImg.WidthRequest = 400;
				mountImg.HeightRequest = 400;
				mountImg.Aspect = Aspect.AspectFit;
				mountImg.Source = ImageSource.FromFile("mount.jpg");
				if (Device.Idiom != TargetIdiom.Tablet)
				{
					sfRangeSlider1.TrackColor = Color.Gray;

				}
			}
		}
	}
}

