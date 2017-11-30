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
	public partial class Outbox_Default : ContentView
	{
		public Outbox_Default ()
		{

			InitializeComponent ();
			mainContentView.HeightRequest = App.ScreenHeight;
			mainContentView.WidthRequest = App.ScreenWidth;
			btn.Image = (FileImageSource)ImageSource.FromFile ("burgericon.png");
			DeviceChanges();
		}

		void Btn_Clicked (object sender, EventArgs e)
		{
			DependencyService.Get<IToggleDrawer>().ToggleDrawer();
		}

		void DeviceChanges()
		{ 
			if (Device.OS == TargetPlatform.Android)
			{
				headLabel.WidthRequest = 260;
			}
			else
			{
				headLabel.WidthRequest = 240;
			}

			if (App.Platform != Platforms.UWP && Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
			{
				btn.WidthRequest = 100;
				btn.BorderColor = Color.FromHex("#1aa1d6");
			}
		}
	}
}
