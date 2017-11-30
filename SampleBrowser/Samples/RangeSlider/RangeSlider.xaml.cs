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
using Syncfusion.SfRangeSlider.XForms;

namespace SampleBrowser
{
	public partial class RangeSlider : SamplePage
	{
		public RangeSlider ()
		{
			InitializeComponent ();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows) 
			{
				RangeSlider_Default linear = new RangeSlider_Default ();
				this.ContentView = linear.getContent ();
				this.PropertyView = linear.getPropertyView ();


			} else if(Device.Idiom==TargetIdiom.Tablet)
			{
				RangeSlider_Tablet linear_Tab = new RangeSlider_Tablet ();
				this.ContentView = linear_Tab.getContent ();
			}
		}
	}
}