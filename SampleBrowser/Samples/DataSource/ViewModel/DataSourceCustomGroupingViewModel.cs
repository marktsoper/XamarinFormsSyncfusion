#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser
{

    public class DataSourceCustomGroupingViewModel
    {
        #region Constructor

        public DataSourceCustomGroupingViewModel()
        {

        }

        #endregion

        #region ItemsSource

        private ObservableCollection<BookDetails> booksDetails = null;

        public ObservableCollection<BookDetails> BooksDetails
        {
            get
            {
                if (booksDetails == null)
                {
                    booksDetails = new BookDetailsRepository().GetBookDetails(60);
                }
                return booksDetails;
            }
        }

        #endregion
    }
}
