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
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class ColorMappings  : SamplePage
	{
		SfMaps maps;
		public ColorMappings ()
		{
			maps = new SfMaps ();
			maps.BackgroundColor = Color.White;
			ShapeFileLayer layer = new ShapeFileLayer();
			layer.Markers.Clear ();
			layer.Uri ="usa_state.shp";
			layer.ShapeIDTableField ="STATE_NAME";
			layer.ShapeIDPath ="Name";
			layer.ItemsSource = GetDataSource ();
			layer.BubbleMarkerSettings = null;
			SetColorMapping(layer.ShapeSettings);
			layer.ShapeSettings.ShapeColorValuePath ="Type";
			maps.Layers.Add (layer);
			this.ContentView  = maps;
		}

		public SfMaps GetView()
		{
			return maps;
		}

		List<AgricultureData> GetDataSource()
		{
			List<AgricultureData> list= new List<AgricultureData>();
			list.Add(new AgricultureData("Alabama" , "Vegetables" , 42));
			list.Add(new AgricultureData( "Alaska" , "Vegetables" , 0 ));
			list.Add(new AgricultureData( "Arizona" , "Rice" , 36 ));
			list.Add(new AgricultureData( "Arkansas" , "Vegetables" , 46 ));
			list.Add(new AgricultureData( "California" , "Rice" , 24 ));
			list.Add(new AgricultureData( "Colorado" , "Rice" , 31));
			list.Add(new AgricultureData( "Connecticut" , "Grains" , 18 ));
			list.Add(new AgricultureData( "Delaware" , "Grains" , 28 ));
			list.Add(new AgricultureData( "District of Columbia" , "Grains" , 27 ));
			list.Add(new AgricultureData( "Florida" , "Rice" , 48 ));
			list.Add(new AgricultureData( "Georgia" , "Rice" , 44));
			list.Add(new AgricultureData( "Hawaii" , "Grains" , 49 ));
			list.Add(new AgricultureData( "Idaho" , "Grains" , 8 ));
			list.Add(new AgricultureData( "Illinois" , "Vegetables" , 26 ));
			list.Add(new AgricultureData( "Indiana" , "Grains" , 21 ));
			list.Add(new AgricultureData( "Iowa" , "Vegetables" , 13 ));
			list.Add(new AgricultureData( "Kansas" , "Rice" , 33 ));
			list.Add(new AgricultureData( "Kentucky" , "Grains" , 32 ));
			list.Add(new AgricultureData( "Louisiana" , "Rice" , 47 ));
			list.Add(new AgricultureData( "Maine" , "Grains" , 3 ));
			list.Add(new AgricultureData( "Maryland" , "Grains" , 30 ));
			list.Add(new AgricultureData( "Massachusetts" , "Grains" , 14 ));
			list.Add(new AgricultureData( "Michigan" , "Grains" , 50 ));
			list.Add(new AgricultureData( "Minnesota" , "Wheat" , 10 ));
			list.Add(new AgricultureData( "Mississippi" , "Vegetables" , 43 ));
			list.Add(new AgricultureData( "Missouri" , "Vegetables" , 35 ));
			list.Add(new AgricultureData( "Montana" , "Grains" , 2 ));
			list.Add(new AgricultureData( "Nebraska" , "Rice" , 15 ));
			list.Add(new AgricultureData( "Nevada" , "Wheat" , 22 ));
			list.Add(new AgricultureData( "New Hampshire" , "Grains" , 12 ));
			list.Add(new AgricultureData( "New Jersey" , "Vegetables" , 20 ));
			list.Add(new AgricultureData( "New Mexico" , "Rice" , 41 ));
			list.Add(new AgricultureData( "New York" , "Vegetables" , 16 ));
			list.Add(new AgricultureData( "North Carolina" , "Rice" , 38 ));
			list.Add(new AgricultureData( "North Dakota" , "Grains" , 4 ));
			list.Add(new AgricultureData( "Ohio" , "Vegetables" , 25 ));
			list.Add(new AgricultureData( "Oklahoma" , "Rice" , 37 ));
			list.Add(new AgricultureData( "Oregon" , "Wheat" , 11 ));
			list.Add(new AgricultureData( "Pennsylvania" , "Vegetables" , 17 ));
			list.Add(new AgricultureData( "Rhode Island" , "Grains" , 19 ));
			list.Add(new AgricultureData( "South Carolina" , "Rice" , 45 ));
			list.Add(new AgricultureData( "South Dakota" , "Grains" , 5 ));
			list.Add(new AgricultureData( "Tennessee" , "Vegetables" , 39 ));
			list.Add(new AgricultureData( "Texas" , "Vegetables" , 40 ));
			list.Add(new AgricultureData( "Utah" , "Rice" , 23 ));
			list.Add(new AgricultureData( "Vermont" , "Grains" , 9 ));
			list.Add(new AgricultureData( "Virginia" , "Rice" , 34 ));
			list.Add(new AgricultureData( "Washington" , "Vegetables" , 1 ));
			list.Add(new AgricultureData( "West Virginia" , "Grains" , 29 ));
			list.Add(new AgricultureData( "Wisconsin" , "Grains" , 7 ));
			list.Add(new AgricultureData( "Wyoming" , "Wheat" , 6 ));
			return list;
		}

		void SetColorMapping(ShapeSetting setting)
		{
			ObservableCollection<ColorMapping> colorMappings= new ObservableCollection<ColorMapping>();

			EqualColorMapping colorMapping1= new EqualColorMapping();
			colorMapping1.Value= "Vegetables";
			colorMapping1.LegendLabel= "Vegetables";
			colorMapping1.Color =Color.FromHex("#29BB9C");
			colorMappings.Add(colorMapping1);

			EqualColorMapping colorMapping2= new EqualColorMapping();
			colorMapping2.Value= "Rice";
			colorMapping2.LegendLabel= "Rice";
			colorMapping2.Color =Color.FromHex("#FD8C48");
			colorMappings.Add(colorMapping2);

			EqualColorMapping colorMapping3= new EqualColorMapping();
			colorMapping3.Value= "Wheat";
			colorMapping3.LegendLabel= "Wheat";
			colorMapping3.Color =Color.FromHex("#E54D42");
			colorMappings.Add(colorMapping3);

			EqualColorMapping colorMapping4= new EqualColorMapping();
			colorMapping4.Value= "Grains";
			colorMapping4.LegendLabel= "Grains";
			colorMapping4.Color =Color.FromHex("#3A99D9");
			colorMappings.Add(colorMapping4);

			setting.ColorMappings = colorMappings;
		}

	}
}


