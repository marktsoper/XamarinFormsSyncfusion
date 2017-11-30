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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class TechnicalIndicators
    {
        public TechnicalIndicators()
        {
            InitializeComponent();
            animationPicker.Items.Add("Accumulation Distribution Indicator");
            animationPicker.Items.Add("Average True Indicator");
            animationPicker.Items.Add("Exponential Moving Average Indicator");
            animationPicker.Items.Add("Momentum Indicator");
            animationPicker.Items.Add("Simple Moving Average Indicator");
            animationPicker.Items.Add("RSI Indicator");
            animationPicker.Items.Add("Triangular Moving Average Indicator");
            animationPicker.Items.Add("MACD Indicator");
            animationPicker.Items.Add("Stochastic Indicator");
            animationPicker.Items.Add("Bollinger Band Indicator");

            animationPicker.SelectedIndex = 4;
            if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
                animationPicker.WidthRequest = 300;

            if (App.Platform == Platforms.WindowsPhone81)
                animationPicker.Margin = new Thickness(10, 0, 10, 0);
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (animationPicker.SelectedIndex)
            {
                case 0:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    AccumulationDistributionIndicator sma = new AccumulationDistributionIndicator();
                    sma.SeriesName = "Series";
                    NumericalAxis numericalAxis = new NumericalAxis();
                    numericalAxis.OpposedPosition = true;
                    numericalAxis.ShowMajorGridLines = false;
                    sma.YAxis = numericalAxis;
                    Chart.TechnicalIndicators.Add(sma);
                    break;
                case 1:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    AverageTrueIndicator sma1 = new AverageTrueIndicator();
                    sma1.SeriesName = "Series";
                    sma1.Period = 14;
                    NumericalAxis numericalAxis1 = new NumericalAxis();
                    numericalAxis1.OpposedPosition = true;
                    numericalAxis1.ShowMajorGridLines = false;
                    sma1.YAxis = numericalAxis1;
                    Chart.TechnicalIndicators.Add(sma1);
                    break;
                case 2:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    ExponentialMovingAverageIndicator sma2 = new ExponentialMovingAverageIndicator();
                    sma2.SeriesName = "Series";
                    sma2.Period = 14;
                    NumericalAxis numericalAxis2 = new NumericalAxis();
                    numericalAxis2.OpposedPosition = true;
                    numericalAxis2.ShowMajorGridLines = false;
                    sma2.YAxis = numericalAxis2;
                    Chart.TechnicalIndicators.Add(sma2);
                    break;
                case 3:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    MomentumIndicator sma3 = new MomentumIndicator();
                    sma3.SeriesName = "Series";
                    sma3.Period = 14;
                    NumericalAxis numericalAxis3 = new NumericalAxis();
                    numericalAxis3.OpposedPosition = true;
                    numericalAxis3.ShowMajorGridLines = false;
                    sma3.YAxis = numericalAxis3;
                    Chart.TechnicalIndicators.Add(sma3);
                    break;
                case 4:
                    if (Chart.TechnicalIndicators.Count > 0)
                        Chart.TechnicalIndicators.RemoveAt(0);
                    SimpleMovingAverageIndicator sma4 = new SimpleMovingAverageIndicator();
                    NumericalAxis numericalAxis4 = new NumericalAxis();
                    numericalAxis4.OpposedPosition = true;
                    numericalAxis4.ShowMajorGridLines = false;
                    sma4.YAxis = numericalAxis4;
                    sma4.SeriesName = "Series";
                    sma4.Period = 14;
                    Chart.TechnicalIndicators.Add(sma4);
                    break;
                case 5:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    RSIIndicator sma5 = new RSIIndicator();
                    sma5.SeriesName = "Series";
                    sma5.Period = 14;
                    NumericalAxis numericalAxis5 = new NumericalAxis();
                    numericalAxis5.OpposedPosition = true;
                    numericalAxis5.ShowMajorGridLines = false;
                    sma5.YAxis = numericalAxis5;
                    Chart.TechnicalIndicators.Add(sma5);
                    break;
                case 6:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    TriangularMovingAverageIndicator sma6 = new TriangularMovingAverageIndicator();
                    sma6.SeriesName = "Series";
                    sma6.Period = 14;
                    NumericalAxis numericalAxis6 = new NumericalAxis();
                    numericalAxis6.OpposedPosition = true;
                    numericalAxis6.ShowMajorGridLines = false;
                    sma6.YAxis = numericalAxis6;
                    Chart.TechnicalIndicators.Add(sma6);
                    break;
                case 7:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    MACDIndicator sma7 = new MACDIndicator();
                    sma7.ItemsSource = (this.BindingContext as ViewModel).TechnicalIndicatorData;
                    sma7.SeriesName = "Series";
                    sma7.LongPeriod = 10;
                    sma7.ShortPeriod = 2;
                    sma7.Trigger = 14;
                    NumericalAxis numericalAxis7 = new NumericalAxis();
                    numericalAxis7.OpposedPosition = true;
                    numericalAxis7.ShowMajorGridLines = false;
                    sma7.YAxis = numericalAxis7;
                    Chart.TechnicalIndicators.Add(sma7);
                    break;
                case 8:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    StochasticIndicator sma8 = new StochasticIndicator();
                    sma8.SeriesName = "Series";
                    sma8.Period = 14;
                    sma8.KPeriod = 5;
                    sma8.DPeriod = 6;
                    NumericalAxis numericalAxis8 = new NumericalAxis();
                    numericalAxis8.OpposedPosition = true;
                    numericalAxis8.ShowMajorGridLines = false;
                    sma8.YAxis = numericalAxis8;
                    Chart.TechnicalIndicators.Add(sma8);
                    break;
                case 9:
                    Chart.TechnicalIndicators.RemoveAt(0);
                    BollingerBandIndicator sma9 = new BollingerBandIndicator();
                    sma9.Period = 14;
                    sma9.SeriesName = "Series";
                    NumericalAxis numericalAxis9 = new NumericalAxis();
                    numericalAxis9.OpposedPosition = true;
                    numericalAxis9.ShowMajorGridLines = false;
                    sma9.YAxis = numericalAxis9;
                    Chart.TechnicalIndicators.Add(sma9);
                    break;
            }
        }
    }
}
