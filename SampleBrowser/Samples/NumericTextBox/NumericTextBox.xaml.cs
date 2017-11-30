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
	public partial class NumericTextBox : SamplePage
	{
		public NumericTextBox ()
		{
			InitializeComponent ();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows) 
			{
				NumericText_Default autocomplete = new NumericText_Default ();
				this.ContentView = autocomplete.getContent ();
				this.PropertyView = autocomplete.getPropertyView ();


			} else if(Device.Idiom==TargetIdiom.Tablet)
			{
				NumericTextBox_Tablet autocompleteTab = new NumericTextBox_Tablet ();
				this.ContentView = autocompleteTab.getContent ();
			}
		}
	}
}

