#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class CircularGauge : INotifyPropertyChanged
    {
        #region Properties
        
        public new event PropertyChangedEventHandler PropertyChanged;

        #region PointerValue

        private double pointerValue = 60;

        public double PointerValue
        {
            get { return pointerValue; }
            set
            {
                pointerValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("PointerValue"));
                }
            }
        }

        #endregion PointerValue

        #endregion Properties

        #region Constructor

        public CircularGauge()
        {
            InitializeComponent();

            circularGauge.BindingContext = this;
            pointer_slider.BindingContext = this;       
          
            #region Conditions

            
            //Stacklayout
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
                main_layout.Padding = new Thickness(-20, 0, 15, 0);
            main_layout.SizeChanged += main_layout_SizeChanged;

            //RadiusFactor
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
                scale.RadiusFactor = 0.28;

            //Major Ticks Offset
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
                major.Offset = Device.OnPlatform(0.05, 0.1, 0.4);
            else
                major.Offset = Device.OnPlatform(0.05, 0.1, 0.3);

            //Label Offset
            if (Device.OS == TargetPlatform.Android)
            {
                scale.LabelOffset = 0.2;
            }
            else
            {
                scale.LabelOffset = 0.1;
            }

            // Header Position
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
                header.Position = Device.OnPlatform(iOS: new Point(.5, .6), Android: new Point(0.5, 0.7), WinPhone: new Point(0.5, 0.7));
            else
                header.Position = Device.OnPlatform(iOS: new Point(.5, .6), Android: new Point(0.5, 0.7), WinPhone: new Point(0.5, 0.7));

            #region Pointer Slider

            //PointerSlider label FontSize
            if (Device.OS == TargetPlatform.iOS)
            {
                pointer_text.FontSize = 15;
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                pointer_text.FontSize = 15;
            }
            else
            {
                pointer_text.FontSize = 20;
            }

            //PointerSlider BackgroundColor
            if (Device.OS == TargetPlatform.WinPhone)
            {
                pointer_slider.BackgroundColor = Color.Gray;
            }
         
            #endregion Pointer Slider

            #endregion Conditions            
        }

        #endregion Constructor

        #region Events

        //main_layout SizeChanged
        void main_layout_SizeChanged(object sender, EventArgs e)
        {
            circularGauge.WidthRequest = 330;
            circularGauge.HeightRequest = 330;
        }

        #endregion Events
    }
}