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
using Syncfusion.SfCalendar.XForms;

namespace SampleBrowser
{
	public partial class InlineEvents : SamplePage
	{
		CalendarEventCollection calendarEventCollection;
		List<String> subjectCollection,colorCollection,subjectCollection2,colorCollection2;
		List<DateTime> startTimeCollection,endTimeCollection,startTimeCollection2,endTimeCollection2;

		public InlineEvents ()
		{
			InitializeComponent ();
			this.Padding = new Thickness (-10);
			if (Device.OS == TargetPlatform.Android)
				calendar.HeaderHeight = 50 * (float)(App.Density / 2);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				sampleLayout.Padding = new Thickness(0, 0, 0, 90);
			}
			calendarEventCollection = new CalendarEventCollection();
			setColors();
			setSubjects();
			setStartTime();
			setEndTime();
			for (int i = 0; i < 5; i++) {
				CalendarInlineEvent appointment = new CalendarInlineEvent();
				appointment.Color = Color.FromHex(colorCollection[i]);
				appointment.Subject = subjectCollection[i];
				appointment.StartTime = startTimeCollection[i];
				appointment.EndTime = endTimeCollection[i];
				calendarEventCollection.Add(appointment);
			}
			for (int i = 0; i < 5; i++) {
				CalendarInlineEvent appointment2 = new CalendarInlineEvent();
				appointment2.Color = Color.FromHex(colorCollection2[i]);
				appointment2.Subject = subjectCollection2[i];
				appointment2.StartTime = startTimeCollection2[i];
				appointment2.EndTime = endTimeCollection2[i];
				calendarEventCollection.Add(appointment2);
			}
			calendar.BindingContext = calendarEventCollection;

		}
		private void setSubjects() {
			subjectCollection = new List<String>();
			subjectCollection2=new List<String>();
			subjectCollection.Add("GoToMeeting");
			subjectCollection.Add("Business Meeting");
			subjectCollection.Add("Conference");
			subjectCollection.Add("Project Status Discussion");
			subjectCollection.Add("Auditing");
			subjectCollection.Add("Client Meeting");
			subjectCollection.Add("Generate Report");
			subjectCollection.Add("Target Meeting");
			subjectCollection.Add("General Meeting");
			subjectCollection.Add("Pay House Rent");
			subjectCollection.Add("Car Service");
			subjectCollection.Add("Medical Check Up");
			subjectCollection.Add("Wedding Anniversary");
			subjectCollection.Add("Sam's Birthday");
			subjectCollection.Add("Jenny's Birthday");
			subjectCollection2.Add ("Auditing");
			subjectCollection2.Add ("Generate Report");
			subjectCollection2.Add ("Conference");
			subjectCollection2.Add ("Client Meeting");
			subjectCollection2.Add ("General Meeting");
			subjectCollection2.Add ("Root's Wedding");
			subjectCollection2.Add ("Travel");
			subjectCollection2.Add ("Conference");
			subjectCollection2.Add ("FootBall Match");
			subjectCollection2.Add ("Office Monitoring");
			subjectCollection2.Add ("Auditing");
			subjectCollection2.Add ("Report Submission");
			subjectCollection2.Add ("Conference");
			subjectCollection2.Add ("Generate Report");
		}
		private void setColors() {
			colorCollection = new List<String>();
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FF00ABA9");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF00ABA9");
			colorCollection2 = new List<String> ();
			colorCollection2.Add("#FF00ABA9");
			colorCollection2.Add("#FFE671B8");
			colorCollection2.Add("#FF339933");
			colorCollection2.Add("#FF339973");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FF00ABA9");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add("#FF1BA1E2");
			colorCollection2.Add("#FFE671B8");
			colorCollection2.Add("#FF00ABA9");
			colorCollection2.Add("#FFE671B8");
			colorCollection2.Add("#FFA2C139");
			colorCollection2.Add ("#FFA2C139");
			colorCollection2.Add("#FF1BA1E2");
			colorCollection2.Add("#FFA2C139");
		}
		private void setStartTime() {
			startTimeCollection = new List<DateTime>();
			startTimeCollection2 = new List<DateTime> ();
			DateTime currentDate = DateTime.Now;
			for (int i = 0; i < 5; i++) {
				DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,12+i,3,0,0);
				startTimeCollection.Add(startTime);
				startTimeCollection2.Add(startTime);
			}
			for (int i = 0; i < 5; i++) {
				DateTime startTime = new DateTime (currentDate.Year,currentDate.Month,12+i,7,0,0);
				startTimeCollection.Add(startTime);
				startTimeCollection2.Add(startTime);
			}

		}
		private void setEndTime() {
			endTimeCollection = new List<DateTime>();
			endTimeCollection2=new List<DateTime>();
			DateTime currentDate = DateTime.Now;
			for (int i = 0; i < 5; i++) {
				DateTime endTime = new DateTime (currentDate.Year,currentDate.Month,12+i,5,0,0);
				endTimeCollection.Add(endTime);
				endTimeCollection2.Add(endTime);
			}
			for (int i = 0; i < 5; i++) {
				DateTime endTime = new DateTime (currentDate.Year,currentDate.Month,12+i,8,0,0);
				endTimeCollection.Add(endTime);
				endTimeCollection2.Add(endTime);
			}


            if (Device.OS == TargetPlatform.WinPhone)
            {
                sampleLayout.Scale = 0.95;
            }
		}
	}
}
