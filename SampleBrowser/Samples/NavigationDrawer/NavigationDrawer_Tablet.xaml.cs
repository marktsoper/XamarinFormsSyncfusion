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
using Syncfusion.SfNavigationDrawer.XForms;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public partial class NavigationDrawer_Tablet : SamplePage
	{
		public NavigationDrawer_Tablet ()
		{
			InitializeComponent();

			var maincontent = new MainContentView_Tablet();
			navigationDrawer.ContentView = maincontent.Content;
			navigationDrawer.ContentView.BackgroundColor = Color.White;
			navigationDrawer.TouchThreshold = 100;

			navigationDrawer.DrawerContentView = getDrawerContent();
			if (Device.OS == TargetPlatform.iOS) {
				navigationDrawer.DrawerHeaderView =getDrawerheader();
				navigationDrawer.DrawerWidth = 200;
				navigationDrawer.DrawerHeaderHeight = 150;
			} else  {
				navigationDrawer.DrawerHeaderView = new DrawerHeader().Content;
				navigationDrawer.DrawerWidth = 200;
				navigationDrawer.DrawerHeaderHeight = 200;
			}
			navigationDrawer.DrawerHeight = (float)App.ScreenHeight;
			navigationDrawer.DrawerFooterHeight = 0;
			navigationDrawer.Duration = 400;
			navigationDrawer.Position = Position.Left;
			navigationDrawer.Transition = Syncfusion.SfNavigationDrawer.XForms.Transition.SlideOnTop;
			this.Padding = new Thickness (-5);
			loadPropertyView ();
		}
		public View getDrawerheader()
		{
			StackLayout headerLayout = new StackLayout ();
			headerLayout.Orientation = StackOrientation.Vertical;
			headerLayout.BackgroundColor = Color.FromHex ("#1aa1d6");
			headerLayout.VerticalOptions = LayoutOptions.CenterAndExpand;
			headerLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
			headerLayout.HeightRequest = 200;
			headerLayout.WidthRequest = 275;
			Image emp = new Image ();
			emp.HeightRequest = 100;
			emp.WidthRequest = 70;
			emp.Source = ImageSource.FromFile("user.png");
			emp.HorizontalOptions = LayoutOptions.CenterAndExpand;
			emp.VerticalOptions = LayoutOptions.Center;
			emp.BackgroundColor = Color.FromHex ("#1aa1d6");
			headerLayout.Children.Add (emp);

			Label header = new Label ();
			header.Text  = "James Pollock";
			header.FontSize = 20;
			header.HeightRequest = 30;
			header.WidthRequest = 140;
			header.TextColor = Color.White;
			header.HorizontalOptions = LayoutOptions.Center;
			header.VerticalOptions = LayoutOptions.Center;
			header.BackgroundColor = Color.FromHex ("#1aa1d6");
			headerLayout.Children.Add (header);
			return headerLayout;
		}
		public View getDrawerContent()
		{
			StackLayout mainStack = new StackLayout ();
			mainStack.Opacity = 1;
			mainStack.Orientation = StackOrientation.Vertical;
			mainStack.HeightRequest = 500;
			mainStack.BackgroundColor = Color.White;

			ObservableCollection<String> list = new ObservableCollection<string> ();
			list.Add ("Home");
			list.Add ("Profile");
			list.Add ("Inbox");
			list.Add ("Outbox");
			list.Add ("Sent");
			list.Add ("Draft");

			ListView listView = new ListView();
			listView.BackgroundColor = Color.White;
            if (Device.OS != TargetPlatform.Windows && Device.OS != TargetPlatform.WinPhone)
            {
                listView.WidthRequest = 200;
            }
			listView.VerticalOptions = LayoutOptions.FillAndExpand;
			listView.ItemsSource = list;
			//mainStack.Children.Add (listView);

			listView.ItemSelected+= ListView_ItemSelected;

			return listView;
		}

		void ListView_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem.ToString ().Equals ("Home")) {
					navigationDrawer.ContentView = new MainContentView_Tablet().Content;

			} else if (e.SelectedItem.ToString ().Equals ("Profile")) {
				
					navigationDrawer.ContentView = new ProfileContentView_Tablet ().Content;
				}

			else if (e.SelectedItem.ToString ().Equals ("Inbox")) {
					navigationDrawer.ContentView = new Inbox_Tablet ().Content;
				}
			else if (e.SelectedItem.ToString ().Equals ("Outbox")) {
					navigationDrawer.ContentView = new Outbox_Tablet ().Content;
			}
			else if (e.SelectedItem.ToString ().Equals ("Sent")) {

					navigationDrawer.ContentView = new SentItems_Tablet ().Content;
				}
			else if (e.SelectedItem.ToString ().Equals ("Draft")) {
					navigationDrawer.ContentView = new Draft_Tablet ().Content;
				}
			if(Device.OS != TargetPlatform.iOS)
				DependencyService.Get<IToggleDrawer>().ToggleDrawer();
		}

		void loadPropertyView ()
		{
			optionLayout.Padding = new Thickness (0,0,10,0);
			transitionPicker.Items.Add ("SlideOnTop");
			transitionPicker.Items.Add ("Push");
			transitionPicker.SelectedIndex = 0;
			transitionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>  {
				switch (transitionPicker.SelectedIndex) {
				case 0:
					{
						navigationDrawer.Transition = Transition.SlideOnTop;
					}
					break;
				case 1:
					{
                        navigationDrawer.Transition = Transition.Push;
					}
					break;				
				}
			};
			positionPicker.Items.Add ("Left");
			positionPicker.Items.Add ("Right");
			positionPicker.SelectedIndex = 0;
			positionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>  {
				switch (positionPicker.SelectedIndex) {
				case 0:
					{
						navigationDrawer.Position = Position.Left;
						navigationDrawer.DrawerHeight = 500;
					}
					break;
				case 1:
					{
						navigationDrawer.Position = Position.Right;
						navigationDrawer.DrawerHeight = 500;
					}
					break;
				}
			};
		}
		public View getContent()
		{
			return this.ContentView;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}
	}
}