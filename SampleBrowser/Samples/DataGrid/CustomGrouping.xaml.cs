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
using Syncfusion.SfDataGrid.XForms;

namespace SampleBrowser
{
	public partial class CustomGrouping : SamplePage
	{
        #region Constructor

        public CustomGrouping ()
		{
			InitializeComponent ();
            this.dataGrid.ItemsSource = viewModel.DailySalesDetails;
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

