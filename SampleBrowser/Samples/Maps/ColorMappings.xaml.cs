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
    public partial class ColorMappings : SamplePage
    {
        public ColorMappings()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.Maps.Layers[0].ItemsSource = GetDataSource();
            this.Maps.Layers [0].LegendSettings.IconSize = new Size (15, 15);
			if ((Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop) && Device.OS == TargetPlatform.Windows)
            {
                this.Maps.Layers[0].LegendSettings.LegendPosition = new Point(400, 500);
            } 
               
            this.Maps.Layers[0].ShapeSelected += (object data) => {
               
                AgricultureData dat = data as AgricultureData;
                if (dat != null)
                {
                    Toast.IsVisible = true;
                    State = countryLabel.Text = dat.Name;
                    Type = populationLabel.Text = dat.Type;

                    Device.StartTimer(new TimeSpan(0, 0, 3), () =>
                    {
                        Toast.IsVisible = false;
                        return false;
                    });
                }
            };

        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        List<AgricultureData> GetDataSource()
        {
            List<AgricultureData> list = new List<AgricultureData>();
            list.Add(new AgricultureData("Alabama", "Vegetables", 42));
            list.Add(new AgricultureData("Alaska", "Vegetables", 0));
            list.Add(new AgricultureData("Arizona", "Rice", 36));
            list.Add(new AgricultureData("Arkansas", "Vegetables", 46));
            list.Add(new AgricultureData("California", "Rice", 24));
            list.Add(new AgricultureData("Colorado", "Rice", 31));
            list.Add(new AgricultureData("Connecticut", "Grains", 18));
            list.Add(new AgricultureData("Delaware", "Grains", 28));
            list.Add(new AgricultureData("District of Columbia", "Grains", 27));
            list.Add(new AgricultureData("Florida", "Rice", 48));
            list.Add(new AgricultureData("Georgia", "Rice", 44));
            list.Add(new AgricultureData("Hawaii", "Grains", 49));
            list.Add(new AgricultureData("Idaho", "Grains", 8));
            list.Add(new AgricultureData("Illinois", "Vegetables", 26));
            list.Add(new AgricultureData("Indiana", "Grains", 21));
            list.Add(new AgricultureData("Iowa", "Vegetables", 13));
            list.Add(new AgricultureData("Kansas", "Rice", 33));
            list.Add(new AgricultureData("Kentucky", "Grains", 32));
            list.Add(new AgricultureData("Louisiana", "Rice", 47));
            list.Add(new AgricultureData("Maine", "Grains", 3));
            list.Add(new AgricultureData("Maryland", "Grains", 30));
            list.Add(new AgricultureData("Massachusetts", "Grains", 14));
            list.Add(new AgricultureData("Michigan", "Grains", 50));
            list.Add(new AgricultureData("Minnesota", "Wheat", 10));
            list.Add(new AgricultureData("Mississippi", "Vegetables", 43));
            list.Add(new AgricultureData("Missouri", "Vegetables", 35));
            list.Add(new AgricultureData("Montana", "Grains", 2));
            list.Add(new AgricultureData("Nebraska", "Rice", 15));
            list.Add(new AgricultureData("Nevada", "Wheat", 22));
            list.Add(new AgricultureData("New Hampshire", "Grains", 12));
            list.Add(new AgricultureData("New Jersey", "Vegetables", 20));
            list.Add(new AgricultureData("New Mexico", "Rice", 41));
            list.Add(new AgricultureData("New York", "Vegetables", 16));
            list.Add(new AgricultureData("North Carolina", "Rice", 38));
            list.Add(new AgricultureData("North Dakota", "Grains", 4));
            list.Add(new AgricultureData("Ohio", "Vegetables", 25));
            list.Add(new AgricultureData("Oklahoma", "Rice", 37));
            list.Add(new AgricultureData("Oregon", "Wheat", 11));
            list.Add(new AgricultureData("Pennsylvania", "Vegetables", 17));
            list.Add(new AgricultureData("Rhode Island", "Grains", 19));
            list.Add(new AgricultureData("South Carolina", "Rice", 45));
            list.Add(new AgricultureData("South Dakota", "Grains", 5));
            list.Add(new AgricultureData("Tennessee", "Vegetables", 39));
            list.Add(new AgricultureData("Texas", "Vegetables", 40));
            list.Add(new AgricultureData("Utah", "Rice", 23));
            list.Add(new AgricultureData("Vermont", "Grains", 9));
            list.Add(new AgricultureData("Virginia", "Rice", 34));
            list.Add(new AgricultureData("Washington", "Vegetables", 1));
            list.Add(new AgricultureData("West Virginia", "Grains", 29));
            list.Add(new AgricultureData("Wisconsin", "Grains", 7));
            list.Add(new AgricultureData("Wyoming", "Wheat", 6));
            return list;
        }

    }
}
