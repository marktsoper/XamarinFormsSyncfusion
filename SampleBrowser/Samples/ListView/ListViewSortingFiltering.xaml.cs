#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class ListViewSortingFiltering : SamplePage
    {
        private SortingFilteringViewModel viewModel;
        static bool isAscending = true;
        private TapGestureRecognizer tapped;
        public ListViewSortingFiltering()
        {
            InitializeComponent();
            viewModel = new SortingFilteringViewModel();
            listView.ItemsSource = viewModel.Items;
            this.headerGrid.BindingContext = viewModel;

            tapped = new TapGestureRecognizer() { Command = new Command(MakeSort) };
            this.sortImage.GestureRecognizers.Add(tapped);
        }

        private void MakeSort()
        {
            listView.DataSource.SortDescriptors.Clear();
            listView.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "Title",
                Direction = isAscending ? ListSortDirection.Ascending : ListSortDirection.Descending
            });
            listView.RefreshView();

            isAscending = isAscending ? false : true;
        }

        SearchBar searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterContacts;
                this.listView.DataSource.RefreshFilter();
            }
            listView.RefreshView();
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var taskInfo = obj as TaskInfo;
            if (taskInfo.Title.ToLower().Contains(searchBar.Text.ToLower())
                || taskInfo.Title.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

        protected override void OnDisappearing()
        {
            listView.Dispose();
            listView = null;
            base.OnDisappearing();
        }
    }
}
