#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SampleBrowser
{
    public class EmployeeDetail : INotifyPropertyChanged
    {
        #region private variables

        private string _employeeID;
        private string _employeeName;
        private string Designation;
        private string _country;

        #endregion

        #region Public Properties

        public string EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                this._employeeID = value;
				RaisePropertyChanged("EmployeeID");
            }
        }

        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                this._employeeName = value;
				RaisePropertyChanged("EmployeeName");
            }
        }

        public string Desigination
        {
            get
            {
                return Designation;
            }
            set
            {
                this.Designation = value;
				RaisePropertyChanged("Desigination");
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                this._country = value;
                RaisePropertyChanged("Country");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }

        #endregion
    }
}
