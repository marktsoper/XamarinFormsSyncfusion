#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser
{
	public partial class MapsGettingStarted : SamplePage
	{
		public MapsGettingStarted ()
		{
			InitializeComponent ();
			this.Maps.Layers[0].ShapeSettings.ColorMappings.Clear(); 
			this.Maps.Layers[0].MarkerSelected+= (Syncfusion.SfMaps.XForms.MapMarker marker) => 
			{
				
				if(marker!=null)
				{
					Toast.IsVisible = true;
					countryLabel.Text= marker.Label;
					populationLabel.Text = marker.Latitude.ToString();

					Device.StartTimer(new TimeSpan(0,0,3), ()=> 
						{ 
							Toast.IsVisible = false;
							return false;
						});
				}

			};
		}
	}

    public class CustomMarker: MapMarker
    {
        public ImageSource ImageName { get; set; }
        public CustomMarker()
        {
            ImageName = ImageSource.FromResource("SampleBrowser.Icons.pin.png");
        }
    }
    
}

