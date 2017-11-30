#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using SampleBrowser;
using SampleBrowser.iOS;

[assembly: Dependency(typeof(IOSVersionDependencyService))]
namespace SampleBrowser.iOS
{
	internal class IOSVersionDependencyService : IIOSVersionDependencyService
	{
		public double GetIOSVersion()
		{
			string[] iOS_Version = (UIDevice.CurrentDevice.SystemVersion).Split('.');
			return Convert.ToDouble(iOS_Version[0]);
		}
	}
}

