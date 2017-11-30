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
	public partial class MainContentView_Default : ContentView
	{
		public MainContentView_Default ()
		{
			InitializeComponent ();
			//mainContentView.HeightRequest = App.ScreenHeight;
			//mainContentView.WidthRequest = App.ScreenWidth;
			btn.Image = (FileImageSource)ImageSource.FromFile ("burgericon.png");
			labl.Text = "\n \t Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus. Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula. Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.";
			labl.BackgroundColor = Color.White;
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
			labl.WidthRequest = App.ScreenWidth - 20;
			labl.HorizontalTextAlignment = TextAlignment.Start;
			labl.HorizontalOptions = LayoutOptions.FillAndExpand;
			mainContentView.HorizontalOptions = LayoutOptions.CenterAndExpand;
		}

	}
}
