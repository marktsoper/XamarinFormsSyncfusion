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
using System.Globalization;

namespace SampleBrowser
{
	public partial class GridGettingStarted : SamplePage
	{
		#region Constructor

		public GridGettingStarted ()
		{
			InitializeComponent ();
            this.dataGrid.ItemsSource = viewModel.OrdersInfo;
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

