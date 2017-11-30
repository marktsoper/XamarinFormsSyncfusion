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
	public partial class ProfileContentView : ContentView
	{
		public ProfileContentView ()
		{
			InitializeComponent ();
			mainContentView.HeightRequest = App.ScreenHeight;
			mainContentView.WidthRequest = App.ScreenWidth;
			profText.Text = "\n" + "\t" +
			"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
				"\n" + "\t" +"when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
			"\n" + "\n" + "James Pollock";
			btn.Image = (FileImageSource)ImageSource.FromFile ("burgericon.png");

			headLabel.WidthRequest= App.ScreenWidth - 80;
		}

		void Btn_Clicked (object sender, EventArgs e)
		{
			DependencyService.Get<IToggleDrawer>().ToggleDrawer();
		}
	}
}

