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
	public partial class Inbox_Tablet : ContentView
	{
		public Inbox_Tablet ()
		{
			InitializeComponent ();
			InitializeComponent ();
			mainContentView.HeightRequest = App.ScreenHeight;
			mainContentView.WidthRequest = App.ScreenWidth;
			btn.Image = (FileImageSource)ImageSource.FromFile ("burgericon.png");
			DeviceChanges();
		}

		void DeviceChanges()
		{ 
			if (Device.OS == TargetPlatform.iOS)
			{
				headLabel.WidthRequest = 680;
			}
			else if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
			{
				headLabel.WidthRequest = App.ScreenWidth;
			}
			else {
				headLabel.WidthRequest = 500;
			}
		}
		void Btn_Clicked (object sender, EventArgs e)
		{
			DependencyService.Get<IToggleDrawer>().ToggleDrawer();
		}

	}
}
