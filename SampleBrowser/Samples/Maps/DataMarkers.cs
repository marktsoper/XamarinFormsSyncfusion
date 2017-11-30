#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfMaps.XForms;
using System.Collections.Generic;
using Xamarin.Forms;
namespace SampleBrowser
{
	public class MapsGettingStarted : SamplePage
	{
		SfMaps maps;
		public MapsGettingStarted ()
		{

			maps = new SfMaps ();
			ShapeFileLayer layer = new ShapeFileLayer ();
			layer.Uri ="world1.shp";
			layer.ShapeSettings.ShapeFill = Color.Gray;
			MapMarker usa= new MapMarker();
			usa.Latitude ="38.8833";
			usa.Longitude="-77.0167";
			usa.Label= "United States";
		
			layer.Markers.Add(usa);


			MapMarker brazil= new MapMarker();
			brazil.Latitude="-15.7833";
			brazil.Longitude="-47.8667";
			brazil.Label = "Brazil";
			layer.Markers.Add(brazil);


			MapMarker india= new MapMarker();
			india.Latitude="21.0000";
			india.Longitude="78.0000";
			india.Label= "India";
			layer.Markers.Add(india);


			MapMarker china= new MapMarker();
			china.Latitude="35.0000";
			china.Longitude="103.0000";
			china.Label = "China";
			layer.Markers.Add(china);



			MapMarker indonesia= new MapMarker();
			indonesia.Latitude="-6.1750";
			indonesia.Longitude="106.8283";
			indonesia.Label="Indonesia";
			layer.Markers.Add(indonesia);

			maps.Layers.Add (layer);
			this.ContentView = maps;
		}

		public SfMaps GetView()
		{
			return maps;
		}
	}
}

