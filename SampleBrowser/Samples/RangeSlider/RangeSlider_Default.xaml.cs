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
	public partial class RangeSlider_Default : SamplePage
	{
		public RangeSlider_Default ()
		{
			InitializeComponent ();

			RangeChangeEvent();
			OptionView();
		}
		void picker1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (positionPicker1.SelectedIndex)
			{
			case 0:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.TopLeft;
					sfRangeSlider2.TickPlacement = TickPlacement.TopLeft;

					break;
				}
			case 1:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.BottomRight;
					sfRangeSlider2.TickPlacement = TickPlacement.BottomRight;
					break;
				}
			case 2:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.Inline;
					sfRangeSlider2.TickPlacement = TickPlacement.Inline;
					break;
				}
			case 3:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.Outside;
					sfRangeSlider2.TickPlacement = TickPlacement.Outside;
					break;
				}
			case 4:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.None;
					sfRangeSlider2.TickPlacement = TickPlacement.None;
					break;
				}
			}
		}
		void picker2_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (positionPicker2.SelectedIndex)
			{
			case 0:
				{
					sfRangeSlider1.ValuePlacement = ValuePlacement.TopLeft;
					sfRangeSlider2.ValuePlacement = ValuePlacement.TopLeft;
					break;
				}
			case 1:
				{
					sfRangeSlider1.ValuePlacement = ValuePlacement.BottomRight;
					sfRangeSlider2.ValuePlacement = ValuePlacement.BottomRight;
					break;
				}
			}
		}
		void toggleStateChanged(object sender, ToggledEventArgs e)
		{
			sfRangeSlider1.ShowValueLabel = e.Value;
			sfRangeSlider2.ShowValueLabel = e.Value;
		}
		void toggleStateChanged1(object sender, ToggledEventArgs e)
		{
			if (e.Value) {
				sfRangeSlider1.SnapsTo = SnapsTo.Ticks;
				sfRangeSlider2.SnapsTo = SnapsTo.Ticks;
			} else {
				sfRangeSlider1.SnapsTo = SnapsTo.None;
				sfRangeSlider2.SnapsTo = SnapsTo.None;
			}
		}

		void RangeChangeEvent()
		{ 
		sfRangeSlider1.RangeChanging += (object sender, RangeEventArgs e) =>
		{
			if (Math.Round(e.Start) < 1)
			{
				if (Math.Round(e.End) == 12)
					timeLabel3.Text = "12 AM - " + Math.Round(e.End) + " PM";
				else
					timeLabel3.Text = "12 AM - " + Math.Round(e.End) + " AM";
			}
			else {
				if (Math.Round(e.End) == 12)
					timeLabel3.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " PM";
				else
					timeLabel3.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " AM";
			}
			if (Math.Round(e.Start) == Math.Round(e.End))
			{
				if (Math.Round(e.Start) < 1)
					timeLabel3.Text = "12 AM";
				else if (Math.Round(e.Start) == 12)
					timeLabel3.Text = "12 PM";
				else
					timeLabel3.Text = Math.Round(e.Start) + " AM";
			}
		};
			sfRangeSlider2.RangeChanging += (object sender, RangeEventArgs e) =>
			 {
				 if (Math.Round(e.Start) < 1)
				 {
					 if (Math.Round(e.End) == 12)
						 timeLabel4.Text = "12 AM - " + Math.Round(e.End) + " PM";
					 else
						 timeLabel4.Text = "12 AM - " + Math.Round(e.End) + " AM";
				 }
				 else {
					 if (Math.Round(e.End) == 12)
						 timeLabel4.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " PM";
					 else
						 timeLabel4.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " AM";
				 }
				 if (Math.Round(e.Start) == Math.Round(e.End))
				 {
					 if (Math.Round(e.Start) < 1)
						 timeLabel4.Text = "12 AM";
					 else if (Math.Round(e.Start) == 12)
						 timeLabel4.Text = "12 PM";
					 else
						 timeLabel4.Text = Math.Round(e.Start) + " AM";
				 }
			 };
		}

		void OptionView()
		{
			toggleButton.Toggled += toggleStateChanged;
			toggleButton2.Toggled += toggleStateChanged1;

			positionPicker1.Items.Add("TopLeft");
			positionPicker1.Items.Add("BottomRight");
			positionPicker1.Items.Add("Inline");
			positionPicker1.Items.Add("Outside");
			positionPicker1.Items.Add("None");
			positionPicker1.SelectedIndex = 1;

			positionPicker1.SelectedIndexChanged += picker1_SelectedIndexChanged;
			positionPicker2.Items.Add("TopLeft");
			positionPicker2.Items.Add("BottomRight");
			positionPicker2.SelectedIndex = 1;

			positionPicker2.SelectedIndexChanged += picker2_SelectedIndexChanged;

			timeLabel3.TextColor = Color.FromHex("#939394");
			timeLabel4.TextColor = Color.FromHex("#939394");

			if (Device.OS == TargetPlatform.Android)
			{
				timeLabel5.FontSize = 12;
				timeLabel5.Text = "   Time: ";
				timeLabel5.HeightRequest = 20;

				timeLabel5.TextColor = Color.FromHex("#939394");
				timeLabel6.FontSize = 12;
				timeLabel6.Text = "   Time: ";
				timeLabel6.HeightRequest = 20;
				departureLabel.Text = "  Departure";
				departureLabel.HeightRequest = 20;
				arrivalLabel.Text = "  Arrival";
				arrivalLabel.HeightRequest = 20;
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				page4.Padding = new Thickness(0, 0, 10, 0);
				emptyLabel.WidthRequest = 200;
				snapsToLabel.WidthRequest = 200;
				sfRangeSlider1.KnobColor = Color.White;
				sfRangeSlider2.KnobColor = Color.White;
				timeLabel5.FontSize = 12;
				timeLabel5.Text = "   Time: ";
				timeLabel5.HeightRequest = 20;
				timeLabel5.TextColor = Color.FromHex("#939394");
				timeLabel6.FontSize = 12;
				timeLabel6.Text = "   Time: ";
				timeLabel6.HeightRequest = 20;
				timeLabel6.TextColor = Color.FromHex("#939394");
				departureLabel.Text = "  Departure";
				departureLabel.HeightRequest = 20;
				departureLabel.TextColor = Color.Black;
				arrivalLabel.Text = "  Arrival";
				arrivalLabel.HeightRequest = 20;

				arrivalLabel.TextColor = Color.Black;
			}
			else {
				timeLabel6.FontSize = 12;
				timeLabel6.Text = "Time: ";
				timeLabel6.HeightRequest = 20;
				timeLabel5.FontSize = 12;
				timeLabel5.Text = "Time: ";
				timeLabel5.HeightRequest = 20;
				departureLabel.Text = "Departure";
				departureLabel.HeightRequest = 20;
				arrivalLabel.Text = "Arrival";
				arrivalLabel.HeightRequest = 20;

			}
			if (Device.OS == TargetPlatform.Android)
			{
				positionPicker1.BackgroundColor = Color.FromRgb(239, 239, 239);
				positionPicker2.BackgroundColor = Color.FromRgb(239, 239, 239);
				placementLabel.FontSize = 20;
				placementLabel.FontSize = 20;
				emptyLabel.FontSize = 20;
				snapsToLabel.FontSize = 20;
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Padding = new Thickness(10, 0, 10, 0);
				sampleLayout1.Padding = new Thickness(0, 0, 10, 0);
				sampleLayout2.Padding = new Thickness(0, 0, 10, 0);
				page4.Padding = new Thickness(10, 0, 10, 0);
				sfRangeSlider1.HeightRequest = 110;
				sfRangeSlider2.HeightRequest = 110;
				emptyLabel.WidthRequest = 150;
				snapsToLabel.WidthRequest = 150;

				positionPicker1.HeightRequest = 90;
				positionPicker2.HeightRequest = 90;

				//.TextColor = Color.White;



				placementLabel.Text = "  " + "Tick Placement";
				placementLabel.HeightRequest = 22;
				placementLabel.Text = "  " + "Label Placement";
				placementLabel.HeightRequest = 22;
				emptyLabel.Text = "  " + "Label";
				emptyLabel.HeightRequest = 22;
				timeLabel1.FontSize = 20;
				timeLabel2.FontSize = 20;
				timeLabel3.FontSize = 20;
				timeLabel4.FontSize = 20;
				timeLabel5.FontSize = 20;
				timeLabel6.FontSize = 20;
			}


			timeLabel3.WidthRequest = sfRangeSlider1.Width;
			timeLabel4.WidthRequest = sfRangeSlider1.Width;
			//emptyLabel.WidthRequest = snapsToLabel.Width;
			timeLabel3.WidthRequest = sfRangeSlider1.Width;
			timeLabel4.WidthRequest = sfRangeSlider1.Width;
		}
		public View getContent()
		{
			return this.ContentView;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}
	}
}

