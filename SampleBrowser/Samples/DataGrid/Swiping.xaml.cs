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
    public partial class Swiping : SamplePage
    {
        #region Field

        Image leftImage;
        Image rightImage;
        int swipedRowIndex;
        private FormsView formView;

        #endregion

        #region Constructor

        public Swiping()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = viewModel.OrdersInfo;
            this.PropertyChanged += Swiping_PropertyChanged;
            formView = new FormsView(dataGrid);
            custumLayout.Children.Add(formView);
        }

        #endregion

        #region Private Methods

        private void Swiping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width" && this.formView != null)
            {
                if (Device.OS != TargetPlatform.WinPhone && Device.OS != TargetPlatform.Windows)
                    formView.Visibility = false;
                else
                    formView.IsVisible = false;
                dataGrid.Opacity = 1.0;
            }
        }

        private void dataGrid_GridTapped(object sender, GridTappedEventsArgs e)
        {
            if (Device.OS != TargetPlatform.WinPhone && Device.OS != TargetPlatform.Windows)
                formView.Visibility = false;
            else
                formView.IsVisible = false;
            dataGrid.Opacity = 1.0;
            dataGrid.IsEnabled = true;
        }

        private void dataGrid_GridViewCreated(object sender, GridViewCreatedEventArgs e)
        {
            dataGrid.GridStyle = new SwipeStyle();
        }

        private void leftImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (leftImage == null)
            {
                leftImage = sender as Image;
                (leftImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command (Edit)});
                leftImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Edit.png");
            }
        }

        private void Edit()
        {
            this.dataGrid.Opacity = 0.25;
            this.dataGrid.IsEnabled = false;
            if (Device.OS != TargetPlatform.Windows)
                formView.LayoutTo(new Rectangle(10, (this.Height / 2) - (350 / 2), this.dataGrid.Width - 20, 350), 250, null);
            else
                formView.LayoutTo(new Rectangle(10, (this.dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - 20, 350), 250, null);
            if (Device.OS != TargetPlatform.WinPhone && Device.OS != TargetPlatform.Windows)
                formView.Visibility = true;
            else
                formView.IsVisible = true;
        }

        private void Delete()
        {
            this.viewModel.OrdersInfo.RemoveAt(swipedRowIndex - 1);
        }

        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
                rightImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Delete.png");
            }
        }

        private void dataGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            formView.BindingContext = e.RowData;
            swipedRowIndex = e.RowIndex;
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
