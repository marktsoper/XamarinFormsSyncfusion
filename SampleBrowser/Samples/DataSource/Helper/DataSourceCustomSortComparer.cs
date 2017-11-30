#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SampleBrowser
{
    public class DataSourceCustomSortComparer : IComparer<Object>, ISortDirection
    {
        Dictionary<string, int> Designations;

        public DataSourceCustomSortComparer()
        {
            Designations = new Dictionary<string, int>();
            Designations.Add("Senior Manager", 1);
            Designations.Add("Manager", 2);
            Designations.Add("Product Manager", 3);
            Designations.Add("Marketing Manager", 4);
            Designations.Add("Team Lead", 5);
            Designations.Add("Software Developer", 6);
            Designations.Add("Design Engineer", 7);
            Designations.Add("Support Engineer", 8);
            Designations.Add("Tester", 9);
            Designations.Add("Network Admin", 10);

        }
        public int Compare(object x, object y)
        {
            int namX;
            int namY;

            //For Customers Type data
            if (x.GetType() == typeof(EmployeeDetail))
            {
                //Calculating the length of CustomerName if the object type is Customers
                namX = GetRankBasedOnDesignation(((EmployeeDetail)x).Desigination);
                namY = GetRankBasedOnDesignation(((EmployeeDetail)y).Desigination);
            }
            else
            {
                namX = x.ToString().Length;
                namY = y.ToString().Length;
            }

            // Objects are compared and return the SortDirection
            if (namX.CompareTo(namY) > 0)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            else if (namX.CompareTo(namY) == -1)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            else
                return 0;
        }

        //Get or Set the SortDirection value
        private ListSortDirection _SortDirection;
        public ListSortDirection SortDirection
        {
            get { return _SortDirection; }
            set { _SortDirection = value; }
        }

        private int GetRankBasedOnDesignation(string designation)
        {
            return this.Designations.FirstOrDefault(x => x.Key == designation).Value;
        }
    }
}
