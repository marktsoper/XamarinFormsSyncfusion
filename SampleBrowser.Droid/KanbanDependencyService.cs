#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Graphics.Drawables;
using SampleBrowser.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(KanbanDependencyService))]
namespace SampleBrowser.Droid
{

	internal class KanbanDependencyService : IKanbanDependencyService
	{

		ActionBar GetActionBar()
		{
			Android.Content.Context context = Xamarin.Forms.Forms.Context;
			ActionBar actionBar = ((Activity)context).ActionBar;
			return actionBar;
		}

		public void ApplyBarColor()
		{
			(GetActionBar()).SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.ParseColor("#D53130")));
		}

		public void RemoveBarColor()
		{
			(GetActionBar()).SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.ParseColor("#33B5E5")));
		}
	}
}