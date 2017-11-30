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
	public partial class Subview : ContentPage
	{
		internal double heightDensity, widthDensity;
		public WeatherData SelectedData;
		public Subview (WeatherData data,Size size,List<WeatherData> dataSource)
		{
			
			SelectedData = data;
			this.HeightRequest = size.Height;
			this.WidthRequest = size.Width;
			this.BindingContext = SelectedData;
			InitializeComponent ();
			this.ExtView.ItemsSource = dataSource;
            ExtView.TotalWidth = size.Width;
			mainGrid.HeightRequest = label.HeightRequest = SubGrid.HeightRequest=  size.Height;
			mainGrid.WidthRequest = label.WidthRequest= SubGrid.WidthRequest= size.Width;
			SubGrid1.HeightRequest = mainGrid.HeightRequest - 180;
			heightDensity = size.Height;
			widthDensity = size.Width;

		}


		internal void UpdateData(int temperature)
		{
			
			label2.Text = temperature.ToString()+"°/12";
		}


	}
}

