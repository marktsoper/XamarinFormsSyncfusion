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
    public partial class BubbleVisualization : SamplePage
    {
        public BubbleVisualization()
        {
            InitializeComponent();
            this.Maps.Layers[0].ItemsSource = GetDataSource();
            this.Maps.Layers[0].ShapeSettings.ColorMappings.Clear(); 
        }


        public List<BubbleData> GetDataSource()
        {
            List<BubbleData> list = new List<BubbleData>();
            list.Add(new BubbleData("Brazil", "BRA", 204436000, 22));
            list.Add(new BubbleData("Russia", "RUS", 146267288, 134));
            list.Add(new BubbleData("United States", "USA", 321174000, 167));
            list.Add(new BubbleData("India", "IND", 1272470000, 73));
            list.Add(new BubbleData("China", "CHI", 1370320000, 30));
            list.Add(new BubbleData("Indonasia", "INO", 255461700, 72));


            return list;
        }
    }

}
