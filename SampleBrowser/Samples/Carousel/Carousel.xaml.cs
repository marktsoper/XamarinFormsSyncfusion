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
	public partial class Carousel : SamplePage
	{
		public Carousel ()
		{
			InitializeComponent ();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows) 
			{
				Carousel_Default busy = new Carousel_Default ();
				this.ContentView = busy.getContent ();
				this.PropertyView = busy.getProperty ();


			} else if(Device.Idiom==TargetIdiom.Tablet)
			{
				Carousel_Tablet busyTab = new Carousel_Tablet ();
				this.ContentView = busyTab.getContent ();
			}
		}
	}
}

