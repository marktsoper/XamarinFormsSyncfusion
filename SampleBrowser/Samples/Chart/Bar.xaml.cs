#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class Bar
    {
        public Bar()
        {
            InitializeComponent();
            Spacing.ValueChanged += Spacing_ValueChanged;
            ColumnWidth.ValueChanged += ColumnWidth_ValueChanged;
        }
        private void ColumnWidth_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            barSeries1.Width = e.NewValue;
            barSeries2.Width = e.NewValue;
            ColumnWidthValue.Text = "width : " + e.NewValue.ToString();
        }

        private void Spacing_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            barSeries1.Spacing = e.NewValue;
            barSeries2.Spacing = e.NewValue;
            SpacingValue.Text = "Spacing : " + e.NewValue.ToString();
        }
    }
}
