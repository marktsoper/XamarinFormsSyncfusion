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

using System.Reflection;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using SampleBrowser;
using SampleBrowser.iOS;

[assembly: Dependency(typeof(KanbanDependencyService))]
namespace SampleBrowser.iOS

{
	internal class KanbanDependencyService : IKanbanDependencyService
    {

		UINavigationController GetCurrentNavigationController()
		{
			UIViewController viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			UINavigationController navigationController = (UINavigationController)viewController.ChildViewControllers[0];
			return navigationController;
		}

		public void ApplyBarColor()
		{
			(GetCurrentNavigationController()).NavigationBar.BarTintColor = UIColor.FromRGB(211.0f / 255.0f, 51.0f / 255.0f, 54.0f / 255.0f);
		}

		public void RemoveBarColor()
		{
			(GetCurrentNavigationController()).NavigationBar.BarTintColor = UIColor.FromRGB(22, 141, 219);
		}
    }
}
