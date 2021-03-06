#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SampleBrowser
{
	public partial class FindAndReplacePage : SamplePage
	{
		public FindAndReplacePage()
		{
			InitializeComponent ();

			this.picker.Items.Add ("Berlin");
			this.picker.Items.Add ("8000");
			this.picker.Items.Add ("Representative");
			this.picker.SelectedIndex = 0;

			if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				this.SampleTitle.HorizontalOptions = LayoutOptions.Start;
				this.Content_1.HorizontalOptions = LayoutOptions.Start;
				this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

				this.SampleTitle.VerticalOptions = LayoutOptions.Center;
				this.Content_1.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
			}
			else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				if (!SampleBrowser.App.isUWP)
				{
					this.Content_1.FontSize = 18.5;
				}
				else
				{
					this.Content_1.FontSize = 13.5;
				}
				this.SampleTitle.VerticalOptions = LayoutOptions.Center;
				this.Content_1.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.VerticalOptions = LayoutOptions.Center;
			}
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;
			application.DefaultVersion = ExcelVersion.Excel2013;

			#region Initializing Workbook
			Assembly assembly = typeof(App).GetTypeInfo().Assembly;
			Stream fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ReplaceOptions.xlsx");

			IWorkbook workbook = application.Workbooks.Open(fileStream);
			//The first worksheet object in the worksheets collection is accessed.
			IWorksheet sheet = workbook.Worksheets[0];
			#endregion

			int replaceIndex = this.picker.SelectedIndex;
			string replaceText;

			switch(replaceIndex)
			{
			default:
			case 0:
				replaceText = "Berlin";
				break;

			case 1:
				replaceText = "8000";
                break;

			case 2:
				replaceText = "Representative";
				break;

			}
			ExcelFindOptions option = ExcelFindOptions.None;

			if (switch1.IsToggled) 
				option |= ExcelFindOptions.MatchCase;

			if (switch2.IsToggled) 
				option |= ExcelFindOptions.MatchEntireCellContent;

			if (entry.Text != null && entry.Text != "")
				sheet.Replace (replaceText, entry.Text, option); 

			workbook.Version = ExcelVersion.Excel2013;

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
				Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("FindAndReplace.xlsx", "application/msexcel", stream);
			else
				Xamarin.Forms.DependencyService.Get<ISave>().Save("FindAndReplace.xlsx", "application/msexcel", stream);
            
		}

	}
}

