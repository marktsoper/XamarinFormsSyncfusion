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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class UnBoundColumn : SamplePage
    {
        #region Constructor

		public UnBoundColumn ()
		{
			InitializeComponent ();
            this.dataGrid.ItemsSource = viewModel.Products;
            this.dataGrid.GridStyle = new Blue();
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
