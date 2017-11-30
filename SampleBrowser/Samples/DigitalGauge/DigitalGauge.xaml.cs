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
	public partial class DigitalGauge : SamplePage
	{
		public DigitalGauge ()
		{
			InitializeComponent ();
			if (Device.Idiom == TargetIdiom.Phone) 
			{
				DigitalGauge_Default digital = new DigitalGauge_Default ();
				this.ContentView = digital.getContent ();
			} else if(Device.Idiom==TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
			{
				DigitalGauge_Tablet digital = new DigitalGauge_Tablet ();
				this.ContentView = digital.getContent ();
			}
		}
	}
}

