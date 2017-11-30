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
using Syncfusion.SfDataGrid.XForms;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class HorizontalScrolling : SamplePage
    {
        #region Constructor

        public HorizontalScrolling()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = viewModel.OrdersInfo;
            if (Device.Idiom == TargetIdiom.Phone)
                this.dataGrid.DefaultColumnWidth = 120;
            else
                this.dataGrid.DefaultColumnWidth = 160;
        }

        #endregion

        #region Private Methods

        private void dataGrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnArgs e)
        {
            e.Column.HeaderFontAttribute = FontAttributes.Bold;
            e.Column.Padding = new Thickness(5, 0, 5, 0);
            e.Column.HeaderCellTextSize = Device.OnPlatform(12, 14, 12);
            e.Column.CellTextSize = Device.OnPlatform(12, 14, 12);
            e.Column.HeaderTextAlignment = TextAlignment.Start;

            if (e.Column.MappingName == "Freight")
            {
                e.Column.TextAlignment = TextAlignment.End;
                e.Column.Format = "C";
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = TextAlignment.Start;
            }
            else if(e.Column.MappingName == "ShipCity")
            {
                e.Column.TextAlignment = TextAlignment.Start;
                e.Column.HeaderText = "Ship City";
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.TextAlignment = TextAlignment.Start;
                e.Column.HeaderText = "Ship Country";
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.TextAlignment = TextAlignment.Center;
                e.Column.HeaderText = "Shipping Date";
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.TextAlignment = TextAlignment.Start;
            }
        }

        #endregion

        #region override

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (!IsPropertyViewVisible)
            {
                dataGrid.Dispose();
                dataGrid = null;
                viewModel = null;
            }
        }

        #endregion
    }
}
