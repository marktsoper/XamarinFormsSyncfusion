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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser
{
    public class DataViewModel
    {
        public ObservableCollection<DataModel> Datas
        {
            get;
            set;
        }

        public ObservableCollection<DataModel> ColumnDatas
        {
            get;
            set;
        }
        public DataViewModel()
        {
            Datas = new ObservableCollection<DataModel>();

            ColumnDatas = new ObservableCollection<DataModel>();

            Datas.Add(new DataModel() { Performance = 10});
            Datas.Add(new DataModel() { Performance = 30 });
            Datas.Add(new DataModel() { Performance = 25});
            Datas.Add(new DataModel() { Performance = 95 });
            Datas.Add(new DataModel() { Performance = 190});
            Datas.Add(new DataModel() { Performance = 40});
            Datas.Add(new DataModel() { Performance = 60 });
            Datas.Add(new DataModel() { Performance = 50 });
            Datas.Add(new DataModel() { Performance = 35 });
            Datas.Add(new DataModel() { Performance = 20 });

            ColumnDatas.Add(new DataModel() {YearPerformance = 20 });
            ColumnDatas.Add(new DataModel() {YearPerformance = 10 });
            ColumnDatas.Add(new DataModel() {YearPerformance = -30 });
            ColumnDatas.Add(new DataModel() {YearPerformance = 60 });
            ColumnDatas.Add(new DataModel() {YearPerformance = 10 });
            ColumnDatas.Add(new DataModel() {YearPerformance = 20 });
        }
    }
}
