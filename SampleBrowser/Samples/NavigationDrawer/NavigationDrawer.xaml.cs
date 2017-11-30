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
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public partial class NavigationDrawer : SamplePage
	{
		public NavigationDrawer ()
		{

			InitializeComponent ();
			if (Device.Idiom == TargetIdiom.Phone) 
			{
				NavigationDrawer_Default autocomplete = new NavigationDrawer_Default ();
				this.ContentView = autocomplete.getContent ();
				this.PropertyView = autocomplete.getPropertyView ();

				this.Padding = new Thickness (-5);
			} else if(Device.Idiom==TargetIdiom.Tablet || Device.Idiom==TargetIdiom.Desktop)
			{
				NavigationDrawer_Tablet autocompleteTab = new NavigationDrawer_Tablet ();
				this.ContentView = autocompleteTab.getContent ();
				this.PropertyView = autocompleteTab.getPropertyView ();
				if(Device.OS == TargetPlatform.iOS)
					this.Padding = new Thickness (-15,-20,-10,0);
			}
		}
	}
}