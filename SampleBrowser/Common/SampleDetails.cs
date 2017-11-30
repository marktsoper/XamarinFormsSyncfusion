#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class SampleDetails : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public SamplePage Sample { get; set; }

        public String ImageId { get; set; }

        public string SampleType { get; set; }

        public string Type { get; set; }

        private bool isSelected = false;

        internal bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanging("IsSelected");
                OnPropertyChanging("BackgroundColor");
                OnPropertyChanging("ForegroundColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Color _backgroundColor = Color.FromHex("#FFEDEDEB");

        public Color BackgroundColor
        {
            get {
                if (IsSelected)
                    return Color.FromHex("#FF86BA35");
                else
                    return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                OnPropertyChanging("BackgroundColor");
            }
        }

        private Color foregroundColor = Color.Black;

        public Color ForegroundColor
        {
            get
            {
                if (IsSelected)
                    return Color.White; 
                else
                     return foregroundColor;
            }
            set
            {
                foregroundColor = value;
                OnPropertyChanging("ForegroundColor");
            }
        }

        void OnPropertyChanging(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}