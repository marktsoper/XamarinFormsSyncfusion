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
using Syncfusion.SfNumericTextBox.XForms;

namespace SampleBrowser
{
	public partial class NumericText_Default : SamplePage
	{
		int precision = 0;
		public NumericText_Default()
		{

			InitializeComponent ();

			OptionView();

		}

		public void OptionView()
		{
			double height = Bounds.Height;
			double width = App.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
				width /= 2;

			//Toggle button
			allowNullToggle.Toggled += ToggleChanged;

			//Localization
			termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
			principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
			interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");

			localePicker.Items.Add("United States");
			localePicker.Items.Add("United Kingdom");
			localePicker.Items.Add("Japan");
			localePicker.Items.Add("France");
			localePicker.Items.Add("Italy");
			localePicker.SelectedIndex = precision;
			localePicker.SelectedIndexChanged += localePicker_Changed;
			 
			//Value Changed
			principalNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
			 {

				 interestNumericTextBox.Value = Convert.ToDouble(interestRateNumericTextBox.Value.ToString()) * Convert.ToDouble(e.Value.ToString()) * Convert.ToDouble(termNumericTextBox.Value.ToString());
			 };

			interestRateNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
			 {
				 interestNumericTextBox.Value = Convert.ToDouble(principalNumericTextBox.Value.ToString()) * Convert.ToDouble(e.Value.ToString()) * Convert.ToDouble(termNumericTextBox.Value.ToString());
			 };

			termNumericTextBox.ValueChanged += (object sender, ValueEventArgs e) =>
			 {
				 interestNumericTextBox.Value = Convert.ToDouble(principalNumericTextBox.Value.ToString()) * Convert.ToDouble(interestRateNumericTextBox.Value.ToString()) * Convert.ToDouble(e.Value.ToString());
			 };

			//Device Settings
			if (Device.OS == TargetPlatform.iOS)
			{
				principalNumericTextBox.WidthRequest = width / 2;
				interestRateNumericTextBox.WidthRequest = width / 2;
				termNumericTextBox.WidthRequest = width / 2;
				interestNumericTextBox.WidthRequest = width / 2;
				allowNullLabel.WidthRequest = width / 2;
				allowNullLabel.VerticalOptions = LayoutOptions.End;
				allowNullToggle.VerticalOptions = LayoutOptions.Start;
				optionLayout.Padding = new Thickness(0, 0, 10, 0);
			}
			else if (Device.OS == TargetPlatform.Android)
			{
				if (App.Density > 2.5)
				{
					principalNumericTextBox.WidthRequest = width / 4;
					interestRateNumericTextBox.WidthRequest = width / 4;
					termNumericTextBox.WidthRequest = width / 4;
					interestNumericTextBox.WidthRequest = width / 4;
					allowNullLabel.WidthRequest = width / 4;
				}
				else
				{
					principalNumericTextBox.WidthRequest = width / 3.5;
					interestRateNumericTextBox.WidthRequest = width / 3.5;
					termNumericTextBox.WidthRequest = width / 3.5;
					interestNumericTextBox.WidthRequest = width / 3.5;
					allowNullLabel.WidthRequest = width / 3.5;
				}
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				principalNumericTextBox.WidthRequest = width / 2;
				interestRateNumericTextBox.WidthRequest = width / 2;
				termNumericTextBox.WidthRequest = width / 2;
				interestNumericTextBox.WidthRequest = width / 2;
				principalNumericTextBox.HeightRequest = 75;
				interestRateNumericTextBox.HeightRequest = 75;
				termNumericTextBox.HeightRequest = 75;
				interestNumericTextBox.HeightRequest = 75;
				localePicker.HeightRequest = 90;
				allowNullToggle.WidthRequest = width / 2;
				allowNullToggle.HorizontalOptions = LayoutOptions.End;
				interestRateNumericTextBox.FormatString = "0 %";
				termNumericTextBox.FormatString = "0 years";
			}
			else
			{
				principalNumericTextBox.WidthRequest = width / 3;
				interestRateNumericTextBox.WidthRequest = width / 3;
				termNumericTextBox.WidthRequest = width / 3;
				interestNumericTextBox.WidthRequest = width / 3;
			}

			if (Device.OS == TargetPlatform.Windows)
			{
				simpleInterestCalculatorLabel.TextColor = Color.Gray;
				findingSimpleInterestLabel.TextColor = Color.Gray;
				formulaLabel.TextColor = Color.Gray;
				principalLabel.TextColor = Color.Gray;
				interestRateLabel.TextColor = Color.Gray;
				termLabel.TextColor = Color.Gray;
				interestLabel.TextColor = Color.Gray;
				interestRateNumericTextBox.FormatString = "0 %";
				termNumericTextBox.FormatString = "0 years";
				interestNumericTextBox.IsEnabled = true;
			}

		}

		void ToggleChanged (object sender, ToggledEventArgs e)
		{
			principalNumericTextBox.AllowNull = e.Value;
			interestRateNumericTextBox.AllowNull = e.Value;
			termNumericTextBox.AllowNull = e.Value;
			interestNumericTextBox.AllowNull = e.Value;
		}

		public void localePicker_Changed(object c, EventArgs e)
		{
			switch (localePicker.SelectedIndex)
			{
				case 0:
					{
						principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
						interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
						interestNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
						termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-US");
						precision = 0;
					}
					break;
				case 1:
					{
						principalNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
						interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
						termNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
						interestNumericTextBox.Culture = new System.Globalization.CultureInfo("en-GB");
						precision = 1;
					}
					break;
				case 2:
					{
						principalNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
						interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
						termNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
						interestNumericTextBox.Culture = new System.Globalization.CultureInfo("ja-JP");
						precision = 2;
					}
					break;
				case 3:
					{
						principalNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
						interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
						termNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
						interestNumericTextBox.Culture = new System.Globalization.CultureInfo("fr-FR");
						precision = 3;
					}
					break;
				case 4:
					{
						principalNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
						interestRateNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
						termNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
						interestNumericTextBox.Culture = new System.Globalization.CultureInfo("it-IT");
						precision = 4;
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

