#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.Drawing;
using Syncfusion.OfficeChart;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class BarChart : SamplePage
    {
        public BarChart()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                this.SampleTitle.HorizontalOptions = LayoutOptions.Start;
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.Content_2.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                this.SampleTitle.VerticalOptions = LayoutOptions.Center;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.Content_2.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
               if (!SampleBrowser.App.isUWP)
                {
                    this.Description.FontSize = 18.5;
                    this.Content_1.FontSize = 18.5;
                    this.Content_2.FontSize = 18.5;
                }
                else
                {
                    this.Description.FontSize = 13.5;
                    this.Content_1.FontSize = 13.5;
                    this.Content_2.FontSize = 13.5;
                }
                this.SampleTitle.VerticalOptions = LayoutOptions.Center;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.Content_2.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            //A new document is created.
            WordDocument document = new WordDocument();
            //Add new section to the Word document
            IWSection section = document.AddSection();
            //Set page margins of the section
            section.PageSetup.Margins.All = 72;
            //Add new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();
            //Apply heading style to the title paragraph
            paragraph.ApplyStyle(BuiltinStyle.Heading1);
            //Apply center alignment to the paragraph
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            //Append text to the paragraph
            paragraph.AppendText("Northwind Management Report").CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
            //Add new paragraph
            paragraph = section.AddParagraph();
            //Set before spacing to the paragraph
            paragraph.ParagraphFormat.BeforeSpacing = 20;
            //Load the excel template as stream
            Stream excelStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Excel_Template.xlsx");
            //Create and Append chart to the paragraph with excel stream as parameter
            WChart barChart = paragraph.AppendChart(excelStream, 1, "B2:C6", 470, 300);
            //Set chart data
            barChart.ChartType = OfficeChartType.Bar_Clustered;
            barChart.ChartTitle = "Purchase Details";
            barChart.ChartTitleArea.FontName = "Calibri (Body)";
            barChart.ChartTitleArea.Size = 14;
            //Set name to chart series            
            barChart.Series[0].Name = "Sum of Purchases";
            barChart.Series[1].Name = "Sum of Future Expenses";
            //Set Chart Data table
            barChart.HasDataTable = true;
            barChart.DataTable.HasBorders = true;
            barChart.DataTable.HasHorzBorder = true;
            barChart.DataTable.HasVertBorder = true;
            barChart.DataTable.ShowSeriesKeys = true;
            barChart.HasLegend = false;
            //Setting background color
            barChart.ChartArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(208, 206, 206);
            barChart.PlotArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(208, 206, 206);
            //Setting line pattern to the chart area
            barChart.PrimaryCategoryAxis.Border.LinePattern = OfficeChartLinePattern.None;
            barChart.PrimaryValueAxis.Border.LinePattern = OfficeChartLinePattern.None;
            barChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
            barChart.PrimaryValueAxis.MajorGridLines.Border.LineColor = Syncfusion.Drawing.Color.FromArgb(175, 171, 171);
            //Set label for primary catagory axis
            barChart.PrimaryCategoryAxis.CategoryLabels = barChart.ChartData[2, 1, 6, 1];
            #region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("BarChart.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("BarChart.docx", "application/msword", stream);
            #endregion
        }
    }
}
