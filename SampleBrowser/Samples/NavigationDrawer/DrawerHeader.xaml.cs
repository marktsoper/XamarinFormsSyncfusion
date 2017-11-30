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

namespace SampleBrowser
{
	public partial class DrawerHeader : ContentView
	{
		public DrawerHeader ()
		{
			InitializeComponent ();
			DeviceChanges();
        }

		void DeviceChanges()
		{ 
			if (Device.Idiom == TargetIdiom.Phone && (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone))
			{
				Grid.SetColumn(userImage, 0);
				Grid.SetColumn(userName, 1);
				userImage.Margin = new Thickness(30, 2, 0, 0);
				userImage.WidthRequest = 100;
				userImage.HeightRequest = 100;

			}
			else if (Device.OS == TargetPlatform.Windows)
			{
				userName.Margin = new Thickness(0, -5, 0, 0);
			}
		}
	}
}
