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
	public partial class NumericUpDown_Tablet : SamplePage
	{
		Picker localePicker;
		Button closeButton;
        StackLayout view;
		Switch autoReverseToggle;
		Entry minimumValueText,maximumValueText;
		Label minimumValueLabel,maximumValueLabel,autoReverseLabel,spinButtonAlignmentLabel;
		int min=0,max=100,align=1;
		bool reverse=false;

		public NumericUpDown_Tablet()
		{
			InitializeComponent();
			getPropertiesWindow();
			adultNumericUpDown.Minimum = 0;
			infantsNumericUpDown.Minimum = 0;
			adultNumericUpDown.Maximum = 100;
			infantsNumericUpDown.Maximum = 100;
			DeviceChanges();
		}
		public void minimumValueText_Changed(object o,TextChangedEventArgs e)
		{
			if(e.NewTextValue.Length > 0){
				adultNumericUpDown.Minimum = int.Parse(e.NewTextValue);
				infantsNumericUpDown.Minimum = int.Parse(e.NewTextValue);
				min=int.Parse(e.NewTextValue);
			}
		}
		public void maximumValueText_Changed(object o,TextChangedEventArgs e)
		{
			if(e.NewTextValue.Length > 0){
				adultNumericUpDown.Maximum = int.Parse(e.NewTextValue);
				infantsNumericUpDown.Maximum = int.Parse(e.NewTextValue);
				max=int.Parse(e.NewTextValue);

			}
		}
		public void autoReverseToggle_Changed(object o , ToggledEventArgs e)
		{
			adultNumericUpDown.AutoReverse = e.Value;
			infantsNumericUpDown.AutoReverse = e.Value;
			reverse = e.Value;
		}
		public void Close_Button(object o, EventArgs e)
		{
            closeAction();
		}
        public void closeAction()
        {
            view.BackgroundColor = Color.White;
            Property_Windows.Children.Add(temp);
            Property_Windows.Children.Remove(view);
        }
		public void localePicker_SelectedIndexChanged(object o, EventArgs e)
		{
			if (localePicker != null) {
				switch (localePicker.SelectedIndex) {
				case 0:
					{
						adultNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Right;
						adultNumericUpDown.TextAlignment = TextAlignment.Start;
						infantsNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Right;
						infantsNumericUpDown.TextAlignment = TextAlignment.Start;
						align = 0;
					}
					break;
				case 1:
					{
						adultNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Left;
						adultNumericUpDown.TextAlignment = TextAlignment.End;
						infantsNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Left;
						infantsNumericUpDown.TextAlignment = TextAlignment.End;
						align = 1;
					}
					break;
				case 2:
					{
						adultNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Both;
						adultNumericUpDown.TextAlignment = TextAlignment.Center;
						infantsNumericUpDown.SpinButtonAlignment = SpinButtonAlignment.Both;
						infantsNumericUpDown.TextAlignment = TextAlignment.Center;
						align = 2;
					}
					break;
				}
			}
		
		}
		public View getContent()
		{
			return this.ContentView;
		}
        public void getPropertiesWindow()
        {
			if (Device.OS == TargetPlatform.iOS) {
				Property_Windows.HeightRequest = 400;
			}
            view = new StackLayout();
            view.HeightRequest = Property_Windows.HeightRequest;
            view.BackgroundColor = Color.FromRgb(250, 250, 250);

            StackLayout propertyLayout = new StackLayout();
            propertyLayout.Padding = new Thickness(10, 0, 0, 0);
            propertyLayout.Orientation = StackOrientation.Horizontal;
            propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
            TapGestureRecognizer tab = new TapGestureRecognizer();
            tab.Tapped += tab_Tapped;
            propertyLayout.GestureRecognizers.Add(tab);
            Label propertyLabel = new Label();
            propertyLabel.Text = "OPTIONS";
            propertyLabel.WidthRequest = 150;
            propertyLabel.VerticalOptions = LayoutOptions.Center;
            propertyLabel.HorizontalOptions = LayoutOptions.Start;
            propertyLabel.FontFamily = "Helvetica";
            propertyLabel.FontSize = 18;
            closeButton = new Button();
			if (Device.OS == TargetPlatform.iOS)
			{
				closeButton.Text = "X";
				closeButton.TextColor = Color.FromRgb(51, 153, 255);
			}
			else
				closeButton.Image = "sfclosebutton.png";
            closeButton.Clicked += Close_Button;
            temp.BackgroundColor = Color.FromRgb(230, 230, 230);
            closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
            Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);

            closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            propertyLayout.Children.Add(propertyLabel);
            propertyLayout.Children.Add(closeButton);

            StackLayout emptyLayout = new StackLayout();
            emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
            emptyLayout.Padding = new Thickness(100, 10, 40, 10);

            StackLayout minimumLayout = new StackLayout();
            minimumLayout.Padding = new Thickness(20, 10, 0, 20);
            minimumLayout.Orientation = StackOrientation.Horizontal;

            minimumValueLabel = new Label();
            minimumValueLabel.Text = "Minimum Value";
            minimumValueLabel.VerticalOptions = LayoutOptions.Center;
            minimumValueLabel.HorizontalOptions = LayoutOptions.End;
            minimumValueLabel.FontSize = 16;
            minimumValueLabel.WidthRequest = 300;
            minimumValueLabel.FontFamily = "Helvetica";

            minimumValueText = new Entry();
            minimumValueText.Text = min.ToString();
            minimumValueText.Keyboard = Keyboard.Numeric;
            minimumValueText.WidthRequest = 150;
            minimumValueText.HorizontalOptions = LayoutOptions.Start;
            minimumValueText.VerticalOptions = LayoutOptions.Center;
            minimumValueText.TextChanged += minimumValueText_Changed;

            minimumLayout.Children.Add(minimumValueLabel);
            minimumLayout.Children.Add(minimumValueText);

            StackLayout maximumLayout = new StackLayout();
            maximumLayout.Padding = new Thickness(20, 10, 0, 20);
            maximumLayout.Orientation = StackOrientation.Horizontal;



            maximumValueLabel = new Label();
            maximumValueLabel.Text = "Maximum Value";
            maximumValueLabel.VerticalOptions = LayoutOptions.Center;
            maximumValueLabel.HorizontalOptions = LayoutOptions.End;
            maximumValueLabel.FontSize = 16;
            maximumValueLabel.WidthRequest = 300;
            maximumValueLabel.FontFamily = "Helvetica";
            maximumValueText = new Entry();
            maximumValueText.Text = max.ToString();
            maximumValueText.Keyboard = Keyboard.Numeric;
            maximumValueText.WidthRequest = 150;
            maximumValueText.HorizontalOptions = LayoutOptions.Start;
            maximumValueText.VerticalOptions = LayoutOptions.Center;
            maximumValueText.TextChanged += maximumValueText_Changed;

            maximumLayout.Children.Add(maximumValueLabel);
            maximumLayout.Children.Add(maximumValueText);


            StackLayout reverseLayout = new StackLayout();
            reverseLayout.Orientation = StackOrientation.Horizontal;
            reverseLayout.Padding = new Thickness(20, 10, 0, 20);

            autoReverseLabel = new Label();
            autoReverseLabel.Text = "Auto Reverse";
            autoReverseLabel.VerticalOptions = LayoutOptions.Center;
            autoReverseLabel.HorizontalOptions = LayoutOptions.End;
            autoReverseLabel.FontSize = 16;
            autoReverseLabel.WidthRequest = 300;
            autoReverseLabel.FontFamily = "Helvetica";
            autoReverseToggle = new Switch();
            autoReverseToggle.IsToggled = reverse;
            autoReverseToggle.HorizontalOptions = LayoutOptions.Start;
            autoReverseToggle.VerticalOptions = LayoutOptions.Center;

            autoReverseToggle.Toggled += autoReverseToggle_Changed;
            reverseLayout.Children.Add(autoReverseLabel);
            reverseLayout.Children.Add(autoReverseToggle);



            StackLayout stack = new StackLayout();
            stack.Orientation = StackOrientation.Horizontal;
            stack.Padding = new Thickness(20, 10, 0, 20);
            spinButtonAlignmentLabel = new Label();
            spinButtonAlignmentLabel.Text = "Spin Button Alignment";
			spinButtonAlignmentLabel.FontFamily="Helvetica";
            spinButtonAlignmentLabel.FontSize = 16;
            spinButtonAlignmentLabel.WidthRequest = 300;
            spinButtonAlignmentLabel.HorizontalOptions = LayoutOptions.End;
            spinButtonAlignmentLabel.VerticalOptions = LayoutOptions.Center;
            localePicker = new Picker();
            localePicker.Items.Add("Right");
            localePicker.Items.Add("Left");
            localePicker.Items.Add("Both");
            localePicker.SelectedIndex = align;
            localePicker.HorizontalOptions = LayoutOptions.Start;
            localePicker.VerticalOptions = LayoutOptions.Center;
            localePicker.WidthRequest = 150;
            localePicker.SelectedIndexChanged += localePicker_SelectedIndexChanged;
            stack.Children.Add(spinButtonAlignmentLabel);
            stack.Children.Add(localePicker);

            emptyLayout.Children.Add(minimumLayout);
            emptyLayout.Children.Add(maximumLayout);
            emptyLayout.Children.Add(reverseLayout);
            emptyLayout.Children.Add(stack);

            view.Children.Add(propertyLayout);
            view.Children.Add(emptyLayout);

            Property_Windows.Children.Insert(0, view);
            Property_Windows.Children.Remove(temp);

        }

		void DeviceChanges()
		{ 
			TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
			tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
			temp.GestureRecognizers.Add(tap_Gestue_Prob);

			double height = Bounds.Height;
			double width = App.ScreenWidth;
			double density = App.Density;

			width /= 2;

			Property_Button.Clicked += Property_Windows_Button_Click;

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
				adultsLayout.Padding = new Thickness(90, 25, 0, 25);
				infantsLayout.Padding = new Thickness(90, 25, 0, 25);
				adultNumericUpDown.WidthRequest = width;
				infantsNumericUpDown.WidthRequest = width;
				adultNumericUpDown.HeightRequest = 32;
				infantsNumericUpDown.HeightRequest = 32;
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Padding = new Thickness(10, 0, 0, 0);
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
				if (maximumValueLabel != null && minimumValueLabel != null && autoReverseLabel != null && spinButtonAlignmentLabel != null)
				{
					minimumValueLabel.TextColor = Color.Gray;
					maximumValueLabel.TextColor = Color.Gray;
					autoReverseLabel.TextColor = Color.Gray;
					spinButtonAlignmentLabel.TextColor = Color.Gray;
				}
			}
		}
        void tab_Tapped(object sender, EventArgs e)
        {
            view.BackgroundColor = Color.White;
            Property_Windows.Children.Add(temp);
            Property_Windows.Children.Remove(view);

        }
        void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
        {
            getPropertiesWindow();
        }
       public void Property_Windows_Button_Click(object sender, EventArgs e)
       {
           getPropertiesWindow();
       }
	}
}

