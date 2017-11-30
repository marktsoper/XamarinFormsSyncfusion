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
using Syncfusion.SfNumericUpDown.XForms;

namespace SampleBrowser
{
	public partial class NumericUpDown_Default : SamplePage
	{
		public NumericUpDown_Default ()
		{
			InitializeComponent ();
			optionView();
			adultNumericUpDown.Minimum = 0;
			infantsNumericUpDown.Minimum = 0;
			adultNumericUpDown.Maximum = 100;
			infantsNumericUpDown.Maximum = 100;

		}
		public void optionView()
		{
			double height = Bounds.Height;
			double width = App.ScreenWidth;
			double density = App.Density;

			minimumValueText.TextChanged += MinimumValueChanged;

			maximumValueText.TextChanged += MaximumValueChanged;

 			//Auto Reversee
			autoReverseToggle.Toggled += (object sender, ToggledEventArgs e) =>
			{
				adultNumericUpDown.AutoReverse = e.Value;
				infantsNumericUpDown.AutoReverse = e.Value;
			};

			localePicker.Items.Add("Right");
			localePicker.Items.Add("Left");
			localePicker.Items.Add("Both");
			localePicker.SelectedIndex = 0;
			localePicker.SelectedIndexChanged += localePickerChanged;

			if (Device.OS == TargetPlatform.Android)
			{
				adultNumericUpDown.FontSize = 16;
				infantsNumericUpDown.FontSize = 16;
				adultNumericUpDown.WidthRequest = width;
				infantsNumericUpDown.WidthRequest = width;

				if (density >= 3)
				{
					adultNumericUpDown.HeightRequest = (int)(density * 35);
					infantsNumericUpDown.HeightRequest = (int)(density * 35);
				}
				else { 
				    adultNumericUpDown.HeightRequest = (int)(density * 30);
					infantsNumericUpDown.HeightRequest = (int)(density * 30);
				}
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				adultNumericUpDown.WidthRequest = width;
				infantsNumericUpDown.WidthRequest = width;
				adultNumericUpDown.HeightRequest = 32;
				infantsNumericUpDown.HeightRequest = 32;
				optionLayout.Padding = new Thickness(0, 0, 10, 0);
				optionLayout.Spacing = 0;
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Padding = new Thickness(10, 0, 0, 0);
				optionLayout.Padding = new Thickness(10, 0, 10, 0);
				adultNumericUpDown.WidthRequest = width;
				infantsNumericUpDown.WidthRequest = width;
				adultNumericUpDown.HeightRequest = 75;
				infantsNumericUpDown.HeightRequest = 75;
				localePicker.HeightRequest = 90;
				autoReverseToggle.WidthRequest = width / 2;
				autoReverseToggle.HorizontalOptions = LayoutOptions.End;
			}
			else
			{
				adultNumericUpDown.WidthRequest = width;
				infantsNumericUpDown.WidthRequest = width;
			}

			if (Device.OS == TargetPlatform.Windows)
			{
				adultLabel.TextColor = Color.Gray;
				infantsLabel.TextColor = Color.Gray;
				minimumValueLabel.TextColor = Color.Gray;
				maximumValueLabel.TextColor = Color.Gray;
				autoReverseLabel.TextColor = Color.Gray;
				spinButtonAlignmentLabel.TextColor = Color.Gray;
			}
		}

		void MinimumValueChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				adultNumericUpDown.Minimum = int.Parse(e.NewTextValue);
				infantsNumericUpDown.Minimum = int.Parse(e.NewTextValue);
			}
			else
			{
				adultNumericUpDown.Minimum = 1;
				infantsNumericUpDown.Minimum = 1;
			}
		}
		void MaximumValueChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				adultNumericUpDown.Maximum = int.Parse(e.NewTextValue);
				infantsNumericUpDown.Maximum = int.Parse(e.NewTextValue);
			}
			else {
				adultNumericUpDown.Maximum = 100;
				infantsNumericUpDown.Maximum = 100;
			}
		}

		void localePickerChanged(object sender, EventArgs e)
		{
			switch (localePicker.SelectedIndex)
			{
				case 0:
					{
						adultNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Right;
						adultNumericUpDown.TextAlignment = TextAlignment.Start;
						infantsNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Right;
						infantsNumericUpDown.TextAlignment = TextAlignment.Start;
					}
					break;
				case 1:
					{
						adultNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Left;
						adultNumericUpDown.TextAlignment = TextAlignment.End;
						infantsNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Left;
						infantsNumericUpDown.TextAlignment = TextAlignment.End;
					}
					break;
				case 2:
					{
						adultNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Both;
						adultNumericUpDown.TextAlignment = TextAlignment.Center;
						infantsNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Both;
						infantsNumericUpDown.TextAlignment = TextAlignment.Center;
					}
					break;
			}
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

