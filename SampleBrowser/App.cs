#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;

namespace SampleBrowser
{
    public class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;
        public static double Density;
        public static bool isUWP;
        public static Platforms Platform;
        public static bool IsDark;

        public App()
        {
            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                MainPage = new ControlsPageWindows();
            }
            else
            {
                NavigationPage page = new NavigationPage(new ControlPage());
                page.BarBackgroundColor = Color.FromHex("#168DDB");
                page.BarTextColor = Color.White;
                
                MainPage = page;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public enum Platforms
    {
        UWP,
        Windows81,
        Android,
        iOS,
        WindowsPhone8,
        WindowsPhone81,
    }
}