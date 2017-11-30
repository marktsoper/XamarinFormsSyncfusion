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
    public class EmployeeDetailsRepository
    {
        #region Fields

        private Random random = new Random();

        #endregion

        #region Constructor

        public EmployeeDetailsRepository()
        {
        }

        #endregion

        #region GetOrderDetails

        public ObservableCollection<EmployeeDetail> GetCutomerDetails(int count)
        {
            ObservableCollection<EmployeeDetail> orderDetails = new ObservableCollection<EmployeeDetail>();

            for (int i = 10001; i <= count + 10000; i++)
            {
                var ord = new EmployeeDetail()
                {
					EmployeeID = i.ToString(),
                    EmployeeName = CustomerNames[random.Next(15)],
                    Desigination = Designations[random.Next(9)],
                    Country = Country[random.Next(5)],
                };
                orderDetails.Add(ord);
            }
            return orderDetails;
        }

        #endregion

        #region MainGrid DataSource

        string[] Designations = new string[] {
			"Senior Manager",
			"Product Manager",
			"Manager",
			"Tester",
			"Software Developer",
			"Support Engineer",
			"Design Engineer",
			"Network Admin",
			"Marketing Manager",
			"Team Lead"
		};

        string[] CustomerNames = new string[] {
			"Kyle",
			"Gina",
			"Irene",
			"Katie",
			"Michael",
			"Oscar",
			"Ralph",
			"Torrey",
			"William",
			"Bill",
			"Daniel",
			"Frank",
			"Brenda",
			"Danielle",
			"Fiona",
			"Howard",
			"Jack",
			"Larry",
			"Holly",
			"Jennifer",
			"Liz",
			"Pete",
			"Steve",
			"Vince",
			"Zeke"
		};

  //      string[] CustomerID = new string[] {
		//	"Alfki",
		//	"Frans",
		//	"Merep",
		//	"Folko",
		//	"Simob",
		//	"Warth",
		//	"Vaffe",
		//	"Furib",
		//	"Seves",
		//	"Linod",
		//	"Riscu",
		//	"Picco",
		//	"Blonp",
		//	"Welli",
		//	"Folig"
		//};

        string[] Country = new string[] {

			"Argentina",
			"Austria",
			"Belgium",
			"Brazil",            
			"Canada",
			"Denmark",
			"Finland",
			"France",
			"Germany",
			"Ireland",
			"Italy",
			"Mexico",
			"Norway",
			"Poland",
			"Portugal",
			"Spain",
			"Sweden",
			"Switzerland",
			"UK",
			"USA",
			"Venezuela"
		};
        #endregion
    }
}
