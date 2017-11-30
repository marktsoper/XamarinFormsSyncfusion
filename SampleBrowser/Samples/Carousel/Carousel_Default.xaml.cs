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
using Syncfusion.SfCarousel.XForms;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public partial class Carousel_Default : SamplePage
    {

        #region Constructor
        public Carousel_Default()
        {
            InitializeComponent();
            carousel.SelectedItemOffset = 0;
			DeviceChanges();    
            carousel.DataSource = GetDataSource();
            OptionSettings();
        }
		#endregion

		void DeviceChanges()
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				carousel.ItemHeight = 300;
				carousel.ItemWidth = 150;
				optionLayout.Padding = new Thickness(0, 0, 10, 0);
			}
		}
        #region Options
        private void OptionSettings()
        {
           
            if (Device.OS == TargetPlatform.Android)
            {
                //if (App.Density > 1.5)
                {
                    carousel.ItemHeight = Convert.ToInt32(250);
                    carousel.ItemWidth = Convert.ToInt32(180);
                }
            }
            offset.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    carousel.Offset = int.Parse(e.NewTextValue);
                }
            };

            scale.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    if (float.Parse(e.NewTextValue) <= 1)
                    {
                        carousel.ScaleOffset = float.Parse(e.NewTextValue);
                    }
                    else
                    {
                        carousel.ScaleOffset = 0.8f;
                    }
                }
            };

            rotateangle.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    if (float.Parse(e.NewTextValue) > 0 && float.Parse(e.NewTextValue) <= 360)
                    {

                        carousel.RotationAngle = int.Parse(e.NewTextValue);
                    }
                    else
                    {
                        carousel.RotationAngle = 45;
                    }
                }
            };
            viewmodePicker.Items.Add("Default");
            viewmodePicker.Items.Add("Linear");
            viewmodePicker.SelectedIndex = 0;
            viewmodePicker.SelectedIndexChanged += viewmodePicker_SelectedIndexChanged;
            Grid.SetColumn(offsetLabel, 0);
            Grid.SetColumn(offset, 1);
            Grid.SetColumn(scaleLabel, 0);
            Grid.SetColumn(scale, 1);
            Grid.SetColumn(rotateLabel, 0);
            Grid.SetColumn(rotateangle, 1);
        }
        void viewmodePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (viewmodePicker.SelectedIndex)
            {
                case 0:
                    carousel.ViewMode = ViewMode.Default;
                    break;
                case 1:
                    carousel.ViewMode = ViewMode.Linear;
                    break;
            }
        }
        #endregion

        #region DataSource
        List<CarouselModel> GetDataSource()
        {
            List<CarouselModel> list = new List<CarouselModel>();
            if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
            {
                list.Add(new CarouselModel("Icons/image1.png"));
                list.Add(new CarouselModel("Icons/image2.png"));
                list.Add(new CarouselModel("Icons/image3.png"));
                list.Add(new CarouselModel("Icons/image4.png"));
                list.Add(new CarouselModel("Icons/image5.png"));
            }
            else
            {
                list.Add(new CarouselModel("image1.png"));
                list.Add(new CarouselModel("image2.png"));
                list.Add(new CarouselModel("image3.png"));
                list.Add(new CarouselModel("image4.png"));
                list.Add(new CarouselModel("image5.png"));
            }
            return list;
        }
        #endregion


        public View getContent()
        {
            return this.ContentView;
        }
        public View getProperty()
        {
            return this.PropertyView;
        }
    }
}
