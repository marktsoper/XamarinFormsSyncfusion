#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;

namespace SampleBrowser
{
	
	public class ViewExt : StackLayout
	{
        public double TotalWidth { get; set; }
		private Xamarin.Forms.DataTemplate itemTemplate;

		public Xamarin.Forms.DataTemplate ItemTemplate
		{
			get { return itemTemplate; }
			set
			{
				itemTemplate = value;
				itemTemplate.Bindings.Add(BindingContextProperty, new Binding { Source = this, Path = "BindingContext"});

			}

		}

		public IList ItemsSource { get; set; }

		public WeatherData SelectedItem;


	}
}


