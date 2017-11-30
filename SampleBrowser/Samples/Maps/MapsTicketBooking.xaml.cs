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

namespace SampleBrowser
{
	public partial class MapsTicketBooking : SamplePage
	{
		public MapsTicketBooking()
		{
			InitializeComponent();
			this.Maps.Layers[0].ItemsSource = GetDataSource();


			Maps.Layers[0].ShapeSelected += (object data) =>
			{

				UpdateSelection();
			};

			Maps.Layers[0].SelectedItems.CollectionChanged += (sender, e) =>
			{


				if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
				{
					UpdateSelection();
				}


			};

			this.ClearButton.Clicked += (sender, e) =>
			{
				if (Maps.Layers[0].SelectedItems.Count != 0)
				{
					Maps.Layers[0].SelectedItems.Clear();
					SelectedLabel.Text = "";
					SelectedLabelCount.Text = "" + Maps.Layers[0].SelectedItems.Count;
					this.ClearButton.IsEnabled = false;
					this.ClearButton.Opacity = 0.5;

				}
			};

		}

		void UpdateSelection()
		{
			string selected = "";
			if (Maps.Layers[0].SelectedItems.Count == 0)
			{
				SelectedLabel.Text = selected;
				SelectedLabelCount.Text = " " ;
				this.ClearButton.IsEnabled = false;
				this.ClearButton.Opacity = 0.5;


			}
			else {

				for (int i = 0; i < Maps.Layers[0].SelectedItems.Count; i++)
				{
					TicketData data = Maps.Layers[0].SelectedItems[i] as TicketData;

					if (data.SeatNumber == "1" || data.SeatNumber == "2" || data.SeatNumber == "8" || data.SeatNumber == "9")
					{
						Maps.Layers[0].SelectedItems.Remove(data);

					}

					else {

						if (Maps.Layers[0].SelectedItems.Count <= 1 && Maps.Layers[0].SelectedItems.Count != 0)
						{
							selected += ("S" + data.SeatNumber);

						}

						else if (i == Maps.Layers[0].SelectedItems.Count - 1)
						{
							selected += ("S" + data.SeatNumber);

						}
						else
						{
							selected += ("S" + data.SeatNumber + ", ");
						}

						this.ClearButton.Opacity = 1;
						this.ClearButton.IsEnabled = true;
						SelectedLabel.Text = selected;
						SelectedLabelCount.Text = "" + Maps.Layers[0].SelectedItems.Count;

					}

				}

			}
		}




		List<TicketData> GetDataSource()
		{
			List<TicketData> list = new List<TicketData>();
			for (int i = 1; i < 22; i++)
			{
				list.Add(new TicketData("" + i));


			}
			return list;
		}
	}
	public class TicketData
	{
		public TicketData(string seatNumber)
		{
			SeatNumber = seatNumber;

		}

		public string SeatNumber
		{
			get;
			set;
		}


	}
}


