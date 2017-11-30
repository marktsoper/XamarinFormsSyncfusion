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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.Data.Extensions;

namespace SampleBrowser
{
    public partial class Filtering : SamplePage
    {
        #region Constructor

        public Filtering()
		{
            InitializeComponent();
            this.dataGrid.ItemsSource = viewModel.BookInfo;
            viewModel.filtertextchanged = OnFilterChanged;
            ColumnsList.SelectedIndex = 0;
        }

        #endregion

		#region CallBacks
       
        void OnColumnsSelectionChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            viewModel.SelectedColumn = newPicker.Items[newPicker.SelectedIndex];
            if (viewModel.SelectedColumn == "All Columns") {
                viewModel.SelectedCondition = "Contains";
                OptionsList.IsVisible = false;
                this.OnFilterChanged ();
            }
            else
            {
                OptionsList.IsVisible = true;
                foreach (var prop in typeof(BookInfo).GetProperties())
                {
                    if (prop.Name == viewModel.SelectedColumn)
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            OptionsList.Items.Clear();
                            OptionsList.Items.Add("Contains");
                            OptionsList.Items.Add("Equals");
                            OptionsList.Items.Add("NotEquals");
                            if (this.viewModel.SelectedCondition == "Equals")
                                OptionsList.SelectedIndex = 1;
                            else if (this.viewModel.SelectedCondition == "NotEquals")
                                OptionsList.SelectedIndex = 2;
                            else
                                OptionsList.SelectedIndex = 0;
                        }
                        else
                        {
                            OptionsList.Items.Clear();
                            OptionsList.Items.Add("Equals");
                            OptionsList.Items.Add("NotEquals");
                            if (this.viewModel.SelectedCondition == "Equals")
                                OptionsList.SelectedIndex = 0;
                            else
                                OptionsList.SelectedIndex = 1;
                        }
                    }
                }
            }
        }

        void OnFilterOptionsChanged (object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            if (newPicker.SelectedIndex >= 0) { 
                viewModel.SelectedCondition = newPicker.Items[newPicker.SelectedIndex];
                if (filterText.Text != null)
				    this.OnFilterChanged ();
            }
        }

        void OnFilterTextChanged (object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
                viewModel.FilterText = "";
            else
                viewModel.FilterText = e.NewTextValue;
        }

        void OnFilterChanged ()
		{
			if (dataGrid.View != null) {
                this.dataGrid.View.Filter = viewModel.FilerRecords;
                this.dataGrid.View.RefreshFilter();
			}
		}

		#endregion

		#region override

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
            if (!IsPropertyViewVisible) {
                dataGrid.Dispose();
                dataGrid = null;
                viewModel = null;
            }
		}

		#endregion
    }
}
