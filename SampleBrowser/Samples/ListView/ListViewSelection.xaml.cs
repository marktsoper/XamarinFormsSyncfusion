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

using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class ListViewSelection : SamplePage
    {
        public ListViewSelectionViewModel ViewModel { get; set; }
        private TapGestureRecognizer editImageTapped;
        private TapGestureRecognizer cancelImageTapped;

        public ListViewSelection()
        {
            InitializeComponent();
           
            ViewModel = new ListViewSelectionViewModel();
            listView.BindingContext = ViewModel;
            listView.ItemsSource = ViewModel.MusicInfo;

            headerGrid.BindingContext = ViewModel;

            editImageTapped = new TapGestureRecognizer() {Command = new Command(EditImageTapped) };
            this.selectionEditImage.GestureRecognizers.Add(editImageTapped);

            cancelImageTapped = new TapGestureRecognizer() {Command = new Command(CancelImageTapped) };
            this.selectionCancelImage.GestureRecognizers.Add(cancelImageTapped);
            listView.ItemHolding += ListView_ItemHolding;
        }

        private void ListView_ItemHolding(object sender, ItemHoldingEventArgs e)
        {
            if(listView.SelectionMode != SelectionMode.Multiple)
                UpdateSelectionTempate();
        }

        private void EditImageTapped()
        {
            UpdateSelectionTempate();
        }

        private void CancelImageTapped()
        {
            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                var item = listView.SelectedItems[i] as Musiqnfo;
                item.IsSelected = false;
            }
            this.listView.SelectedItems.Clear();
            UpdateSelectionTempate();
        }

        private void ListView_OnSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (listView.SelectionMode == SelectionMode.Multiple)
            {
                ViewModel.HeaderInfo = listView.SelectedItems.Count + " Selected";
                for (int i = 0; i < e.AddedItems.Count; i++)
                {
                    var item = e.AddedItems[i];
                    (item as Musiqnfo).IsSelected = true;
                }
                for (int i = 0; i < e.RemovedItems.Count; i++)
                {
                    var item = e.RemovedItems[i];
                    (item as Musiqnfo).IsSelected = false;
                }
            }
        }

        private void UpdateSelectionTempate()
        {
            if (listView.SelectedItems.Count > 0 || selectionEditImage.IsVisible)
            {
                listView.SelectionMode = SelectionMode.Multiple;
                listView.SelectionBackgroundColor = Color.Transparent;
                listView.SelectedItems.Clear();
                ViewModel.HeaderInfo = listView.SelectedItems.Count + " Selected";
                ViewModel.TitleInfo = "";
                ViewModel.IsVisible = true;
                selectionEditImage.IsVisible = false;
            }
            else
            {
                listView.SelectionMode = SelectionMode.Single;
                listView.SelectionBackgroundColor = Color.FromRgb(228, 228, 228);
                ViewModel.HeaderInfo = "";
                ViewModel.TitleInfo = "Music Library";
                ViewModel.IsVisible = false;
                selectionEditImage.IsVisible = true;
            }
        }

        protected override void OnDisappearing()
        {
            listView.Dispose();
			listView.ItemHolding -= ListView_ItemHolding;
            listView = null;
            base.OnDisappearing();
        }
    }
}
