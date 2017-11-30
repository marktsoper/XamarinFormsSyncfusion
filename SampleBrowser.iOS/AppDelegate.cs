#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using SampleBrowser;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using UIKit;
using Syncfusion.SfMaps.XForms.iOS;
using Syncfusion.SfTreeMap.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.SfGauge.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.SfBarcode.XForms.iOS;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfSchedule.XForms.iOS;
using Syncfusion.SfChart.iOS;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfRotator.XForms.iOS;
using Syncfusion.SfNumericUpDown.XForms.iOS;
using Syncfusion.SfCarousel.XForms.iOS;
using Syncfusion.SfNavigationDrawer.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.SfKanban.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfSparkline.XForms.iOS;
using Syncfusion.ListView.XForms.iOS;

namespace SampleBrowser_Forms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

			App.ScreenWidth = UIScreen.MainScreen.Bounds.Width;
            App.Platform = Platforms.iOS;
            App.ScreenHeight = UIScreen.MainScreen.Bounds.Height;

            new SfPdfDocumentViewRenderer();

            new SfChartRenderer();

			new SfSparklineRenderer();

			new SfBusyIndicatorRenderer ();

			new SfBarcodeRenderer ();

			new SfScheduleRenderer ();
			
			new SfDigitalGaugeRenderer ();

			new SfLinearGaugeRenderer ();

			new SfRangeSliderRenderer ();

			new SfAutoCompleteRenderer ();

			new SfNumericTextBoxRenderer ();

			new SfRatingRenderer();
            
            new SfPullToRefreshRenderer();

			new SfRotatorRenderer ();

			new SfCalendarRenderer ();

			new SfCarouselRenderer ();

			new SfMapsRenderer ();

			new SfTreeMapRenderer ();

			new SfNumericUpDownRenderer ();

			new SfNavigationDrawerRenderer ();

			new SfKanbanRenderer();

            SfDataGridRenderer.Init();
			SfListViewRenderer.Init();

            LoadApplication(new App());

			app.StatusBarHidden			    = false;
			app.StatusBarStyle				= UIStatusBarStyle.LightContent;

            return base.FinishedLaunching(app, options);
        }
    }
}
