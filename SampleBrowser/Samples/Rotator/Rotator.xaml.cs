#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
	public partial class Rotator : SamplePage
	{
		public Rotator ()
		{
			InitializeComponent ();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows || Device.Idiom == TargetIdiom.Desktop) 
			{
				Rotator_Default rotator = new Rotator_Default ();
				this.ContentView = rotator.getContent ();


			} else if(Device.Idiom==TargetIdiom.Tablet)
			{
				Rotator_TabletView rotator_tab = new Rotator_TabletView ();
				this.ContentView = rotator_tab.getContent ();
			}
		}
	}
}

