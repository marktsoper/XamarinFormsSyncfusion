#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class ListViewSwiping : SamplePage
    {
        private ListViewSwipingViewModel viewModel;
        Image leftImage;
        Image rightImage;
        int itemIndex = -1;

        public ListViewSwiping()
        {
            InitializeComponent();
            viewModel = new ListViewSwipingViewModel();
            listView.ItemsSource = viewModel.InboxInfo;
            listView.SwipeStarted += ListView_SwipeStarted;
            listView.SwipeEnded += ListView_SwipeEnded;
        }

        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = -1;
        }

        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = e.ItemIndex;
        }

        private void leftImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (leftImage == null)
            {
                leftImage = sender as Image;
                (leftImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(SetFavorites) });
                leftImage.Source = ImageSource.FromResource("SampleBrowser.Icons.ListView.Favorites.png");
            }
        }

        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
                rightImage.Source = ImageSource.FromResource("SampleBrowser.Icons.ListView.Delete.png");
            }
        }

        private void SetFavorites()
        {
            if (itemIndex >= 0)
            {
                var item = viewModel.InboxInfo[itemIndex];
                item.IsFavorite = !item.IsFavorite;
            }
            this.listView.ResetSwipe();
        }

        private void Delete()
        {
            if (itemIndex >= 0)
                viewModel.InboxInfo.RemoveAt(itemIndex);
            this.listView.ResetSwipe();
        }

        protected override void OnDisappearing()
        {
            listView.SwipeStarted -= ListView_SwipeStarted;
            listView.SwipeEnded -= ListView_SwipeEnded;
            listView.Dispose();
            listView = null;
            base.OnDisappearing();
        }
    }
}
