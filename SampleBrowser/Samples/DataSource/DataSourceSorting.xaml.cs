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
using Syncfusion.DataSource;

namespace SampleBrowser
{
    public partial class DataSourceSorting : SamplePage
    {
        ContatsViewModel viewModel;
        DataSource sfDataSource;
        public DataSourceSorting()
        {
            InitializeComponent();
            viewModel = new ContatsViewModel();
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            sfDataSource.BeginInit();
            sfDataSource.SortDescriptors.Add(new SortDescriptor("ContactName"));
            sfDataSource.EndInit();
            listView.ItemsSource = sfDataSource.DisplayItems;
            optionList.SelectedIndex = 0;
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sfDataSource != null)
            {
                this.sfDataSource.Filter = FilterContacts;
                this.sfDataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            var contacts = obj as Contacts;
            if (contacts.ContactName.ToLower().Contains(filterText.Text.ToLower())
                || contacts.ContactNumber.ToLower().Contains(filterText.Text.ToLower()))
                return true;
            else
                return false;
        }

        private void OnSortDirectionChanged(object sender, EventArgs e)
        {
            Picker newPicker = (Picker)sender;
            var direction = newPicker.Items[newPicker.SelectedIndex];
            sfDataSource.BeginInit();

            sfDataSource.SortDescriptors.Clear();
            sfDataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "ContactName",
                Direction = direction == "Ascending" ? Syncfusion.DataSource.ListSortDirection.Ascending : Syncfusion.DataSource.ListSortDirection.Descending
            });
            sfDataSource.EndInit();
        }
    }
}

