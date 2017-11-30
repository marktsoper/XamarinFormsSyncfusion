#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class ListViewGrouping : SamplePage
    {
        private ListViewGroupingViewModel groupViewModel;
        public ListViewGrouping()
        {
            InitializeComponent();
            groupViewModel = new ListViewGroupingViewModel();
            listView.ItemsSource = groupViewModel.ContactsInfo;
            InitializeSortDescriptor();
            InitializeGroupDescriptor();
        }

        private void InitializeSortDescriptor()
        {
            listView.DataSource.SortDescriptors.Add(new SortDescriptor("ContactName"));
        }

        private void InitializeGroupDescriptor()
        {
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "ContactName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as ListViewContactsInfo);
                    return item.ContactName[0].ToString();
                },
            });

        }

        protected override void OnDisappearing()
        {
            listView.Dispose();
            listView = null;
            base.OnDisappearing();
        }
    }
}
