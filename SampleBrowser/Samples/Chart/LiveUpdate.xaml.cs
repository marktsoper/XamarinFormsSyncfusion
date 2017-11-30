#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class LiveUpdate
    {
        ViewModel viewModel;
        public LiveUpdate()
        {
            InitializeComponent();
            viewModel = Chart.BindingContext as ViewModel;
            viewModel.LoadData1();
            (Chart.SecondaryAxis as NumericalAxis).Maximum = 1.5;
            (Chart.SecondaryAxis as NumericalAxis).Minimum = -1.5;
        }
    }
}
