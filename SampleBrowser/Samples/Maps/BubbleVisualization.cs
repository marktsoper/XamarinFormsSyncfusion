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
	public class BubbleVisualization : SamplePage
	{
		SfMaps maps;
		public BubbleVisualization ()
		{

			maps = new SfMaps ();
			ShapeFileLayer layer = new ShapeFileLayer ();
			maps.BackgroundColor = Color.White;
			layer.Uri ="world1.shp";
			layer.ItemsSource = GetDataSource();
			layer.ShapeIDPath = "Country";
			layer.ShapeIDTableField = "NAME";
			layer.ShapeSettings = new ShapeSetting ();

			layer.ShowMapItems = true;
			layer.ShapeSettings.ShapeValuePath= "Code";
			layer.ShapeSettings.ShapeFill = Color.FromHex ("#A9D9F7");

			BubbleMarkerSetting marker = new BubbleMarkerSetting ()
			{  Fill = Color.FromHex ("#ffa500"), ValuePath = "Population", MinSize=15,MaxSize=25 };
			layer.BubbleMarkerSettings = marker;
			maps.Layers.Add (layer);
			this.ContentView  = maps;
		}

		public SfMaps GetView()
		{
			return maps;
		}

		public List<BubbleData> GetDataSource()
		{
			List<BubbleData> list = new List<BubbleData> ();
			list.Add(new BubbleData("Brazil","BRA",204436000 ,22));
			list.Add(new BubbleData("Russia","RUS" ,146267288,134));
			list.Add(new BubbleData("USA","USA" ,321174000,167));
			list.Add(new BubbleData("India","IND" ,1272470000,73));
			list.Add(new BubbleData("China","CHI" ,1370320000,30));
			list.Add(new BubbleData("Indonasia","INO" ,255461700,72));


			return list;
		}
	}
}

