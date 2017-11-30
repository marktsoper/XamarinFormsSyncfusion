#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class AutoRowHeight : SamplePage
    {
        public AutoRowHeight()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = viewModel.ReleaseInformation;
            this.dataGrid.QueryRowHeight += DataGrid_QueryRowHeight;
            this.dataGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            if (Device.Idiom != TargetIdiom.Phone)
            {
                GridTextColumn sno = new GridTextColumn();
                sno.MappingName = "SNo";
                sno.HeaderText = "S.No";
                sno.Padding = 5;
                sno.ColumnSizer = ColumnSizer.Auto;
                sno.HeaderFontAttribute = FontAttributes.Bold;
                sno.HeaderTextAlignment = TextAlignment.Center;
                sno.TextAlignment = TextAlignment.Center;
            this.dataGrid.Columns.Insert(0,sno);
            }
        }

        private void DataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            double height = SfDataGridHelpers.GetRowHeight(dataGrid, e.RowIndex);
            if (e.RowIndex == 0)
            {
                e.Height = 45;
                e.Handled = true;
            }
            else
            {
                if (height > 35)
                    e.Height = height;
                e.Handled = true;
            }
            //if (e.RowIndex > 0)
            //    e.Height = 100;
            //e.Handled = true;
        }
    }
}
