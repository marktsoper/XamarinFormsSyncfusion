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
using System.Windows.Input;

namespace SampleBrowser
{
    extern alias Calculate;
    public class ComputeCommand : ICommand
    {
        private FunctionsLibraryViewModel viewModel;
        private CalcData calcData;
        public ComputeCommand(FunctionsLibraryViewModel _viewModel)
        {
            viewModel = _viewModel;
            calcData = viewModel._CalcData;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            calcData.SetValueRowCol(viewModel.TxtA1, 1, 1);
            calcData.SetValueRowCol(viewModel.TxtA2, 2, 1);
            calcData.SetValueRowCol(viewModel.TxtA3, 3, 1);
            calcData.SetValueRowCol(viewModel.TxtA4, 4, 1);
            calcData.SetValueRowCol(viewModel.TxtA5, 5, 1);
            calcData.SetValueRowCol(viewModel.TxtB1, 1, 2);
            calcData.SetValueRowCol(viewModel.TxtB2, 2, 2);
            calcData.SetValueRowCol(viewModel.TxtB3, 3, 2);
            calcData.SetValueRowCol(viewModel.TxtB4, 4, 2);
            calcData.SetValueRowCol(viewModel.TxtB5, 5, 2);
            calcData.SetValueRowCol(viewModel.TxtC1, 1, 3);
            calcData.SetValueRowCol(viewModel.TxtC2, 2, 3);
            calcData.SetValueRowCol(viewModel.TxtC3, 3, 3);
            calcData.SetValueRowCol(viewModel.TxtC4, 4, 3);
            calcData.SetValueRowCol(viewModel.TxtC5, 5, 3);

            viewModel.TxtResult = viewModel.Engine.ParseAndComputeFormula(viewModel.TxtGen);
        }
		
		private void RaiseCanExcuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }

    public class CalcData : Calculate.Syncfusion.Calculate.ICalcData
    {
        public CalcData()
        {

        }

        public event Calculate.Syncfusion.Calculate.ValueChangedEventHandler ValueChanged;

        Dictionary<string, object> values = new Dictionary<string, object>();
        public object GetValueRowCol(int row, int col)
        {
            object value = null;

            var key = Calculate.Syncfusion.Calculate.RangeInfo.GetAlphaLabel(col) + row;

            this.values.TryGetValue(key, out value);

            return value;
        }

        public void SetValueRowCol(object value, int row, int col)
        {
            var key = Calculate.Syncfusion.Calculate.RangeInfo.GetAlphaLabel(col) + row;

            if (!values.ContainsKey(key))
                values.Add(key, value);
            else if (values.ContainsKey(key) && values[key] != value)
                values[key] = value;
        }

        public void WireParentObject()
        {
            
        }

        private void OnValueChanged(int row, int col, string value)
        {
            if (ValueChanged != null)
                ValueChanged(this, new Calculate.Syncfusion.Calculate.ValueChangedEventArgs(row, col, value));
        }
    }
}
