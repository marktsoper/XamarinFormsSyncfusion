#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfPullToRefresh.XForms;
using System.Threading;

namespace SampleBrowser
{

	public partial class PullToRefreshView : SamplePage
	{
		
		Subview page;
		List<WeatherData> DataSource;

		Random randomNumber = new Random();
		SfPullToRefresh pull;
		string[] temperatures = new string[] { "humid","rainy","cloudy","windy","warm" };
		public PullToRefreshView ()
		{
			
			InitializeComponent ();
			pull = new SfPullToRefresh ();
			DataSource = GetWeatherData();
			this.Padding = new Thickness (0,-10,0,0);
			pull.TransitionMode = TransitionType.SlideonTop;
			transitionType.Items.Add ("Push");
			transitionType.Items.Add ("SlideOnTop");
			transitionType.SelectedIndex = 1;
			transitionType.SelectedIndexChanged+= (object sender, EventArgs e) => {
			if(transitionType.SelectedIndex==0)
				{
					if (Device.OS != TargetPlatform.Android)
					{
						pull.ProgressBackground = Color.FromRgb(3, 155, 229);
						pull.ProgressStrokeColor = Color.White;
					}
                    pull.TransitionMode = TransitionType.Push;
				}
				else
				{
					if (Device.OS != TargetPlatform.Android)
					{
						pull.ProgressBackground = Color.White;
						pull.ProgressStrokeColor = Color.FromRgb(3, 155, 229);
					}
                    pull.TransitionMode = TransitionType.SlideonTop;
				}
			};	

			pull.RefreshedEvent += Pull_pullToRefreshedEvent;
            if (Device.OS == TargetPlatform.iOS)
            {
                pull.SizeChanged += Pull_SizeChanged;
            }

            if(Device.OS == TargetPlatform.Windows)
            {
                this.ContentView = pull;
                transitionType.SelectedIndex = 0;
                pull.SizeChanged += Pull_SizeChanged;
                pull.TransitionMode = TransitionType.Push;
                pull.ProgressRadius = 9;
            }
            
        }

        private void Pull_SizeChanged(object sender, EventArgs e)
        {
            pull.WidthRequest = pull.Bounds.Width;
            pull.HeightRequest = pull.Bounds.Height+10;
           page = new Subview(DataSource[0], new Size(pull.WidthRequest, pull.HeightRequest), DataSource);
            pull.PullableContent = page.Content;
        }

        List<WeatherData> GetWeatherData()
		{
			DateTime now = DateTime.Now;
			List<WeatherData> array = new List<WeatherData>();
			for (int i = 0; i < 7; i++)
			{
				WeatherData data = GetData(now.AddDays(i));
				data.Type = temperatures[i % temperatures.Length]+".png";
				data.SelectedType = temperatures[i % temperatures.Length] + "selected.png";
				array.Add(data);
			}
			return array;
		}

		WeatherData GetData(DateTime date)
		{
			string month;
			DateTime now = DateTime.Now;
			month = "" + now.DayOfWeek.ToString() +", "+" " + now.ToString("MMMM") + " " + now.Date.Day.ToString();
			return new WeatherData(date.ToString("dddd"),month,randomNumber.Next(20,50).ToString()+"","","");
		}

		protected override void OnSizeAllocated(double width, double height)
		{
            
            if (Device.OS == TargetPlatform.iOS)
            {
                height -= 100;
            }
            page = new Subview(DataSource[0], new Size(width, height+10),DataSource);
			pull.PullableContent = page.Content;
            this.ContentView = pull;
            base.OnSizeAllocated(width, height);
		}

		 void Pull_pullToRefreshedEvent (object sender)
		{

			Device.StartTimer(new TimeSpan(0,0,2), ()=> 
				{ 
					Random rnd = new Random();
				    int i = rnd.Next(20, 40);
				    page.UpdateData(i);
                 	pull.Refresh();
					return false;
				});

		}

	}
}

