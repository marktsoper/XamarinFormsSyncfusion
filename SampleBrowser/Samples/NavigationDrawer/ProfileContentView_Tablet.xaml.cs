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
using Syncfusion.SfNavigationDrawer.XForms;

namespace SampleBrowser
{
	public partial class ProfileContentView_Tablet : ContentView
	{
		public ProfileContentView_Tablet ()
		{
			InitializeComponent ();
			//mainContentView.HeightRequest = App.ScreenHeight;
			//mainContentView.WidthRequest = App.ScreenWidth;
			btn.Image = (FileImageSource)ImageSource.FromFile ("burgericon.png");
			DeviceChanges();
        }

		void Btn_Clicked (object sender, EventArgs e)
		{
			DependencyService.Get<IToggleDrawer>().ToggleDrawer();
		}

		void DeviceChanges()
		{ 
		if (Device.OS == TargetPlatform.iOS)
			{
				profText.Text = "\n" + "\t" +
				"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
				"\n" + "\t" + "when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
				"\n" + "\n" + "James Pollock";
				profText.WidthRequest = 900;
				profileExplanation.Padding = new Thickness(10, 0, 10, 0);
			}
			else {
				profText.Text = "\n" + "\t" +
					"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
					"\n" + "\t" + "when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
					"\n" + "\n" + "James Pollock";
			}
			if (Device.OS == TargetPlatform.iOS)
			{
				headLabel.WidthRequest = 680;
			}
			else if (Device.OS == TargetPlatform.Android)
			{
				headLabel.WidthRequest = 500;
				profText.WidthRequest = 500;

			}
			else if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
			{
				headLabel.WidthRequest = App.ScreenWidth;
				profText.WidthRequest = App.ScreenWidth;

			}
		}
	}
}
