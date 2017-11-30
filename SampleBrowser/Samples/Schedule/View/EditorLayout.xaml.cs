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
using Syncfusion.SfSchedule.XForms;

namespace SampleBrowser
{
    public partial class EditorLayout : StackLayout
    {
        private ScheduleAppointment selectedAppointment;
        private DateTime selectedDate;


        public EditorLayout()
        {
            InitializeComponent();
            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;
			if (App.Platform == Platforms.UWP && Device.Idiom == TargetIdiom.Phone)
			{
				StartdateTimePicker_layout.ColumnDefinitions.Clear();
				Grid.SetColumn(start_datepicker_layout, 0);
				Grid.SetRow(start_datepicker_layout, 0);
				Grid.SetColumn(start_timepicker_layout, 0);
				Grid.SetRow(start_timepicker_layout, 1);
				StartdateTimePicker_layout.HeightRequest = 80;
				subject_layout.Padding = new Thickness(0, 10, 0, 0);
				location_layout.Padding = new Thickness(0, 20, 0, 0);
				startTimeLabel_layout.Padding = new Thickness(0, 20, 0, 0);
				StartdateTimePicker_layout.Padding = new Thickness(0, -20, 0, 0);
				StartdateTimePicker_layout.RowDefinitions = new RowDefinitionCollection()
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				};
				EndDateTimePicker_layout.ColumnDefinitions.Clear();
				Grid.SetColumn(end_datepicker_layout, 0);
				Grid.SetRow(end_datepicker_layout, 0);
				Grid.SetColumn(end_timepicker_layout, 0);
				Grid.SetRow(end_timepicker_layout, 1);
				EndDateTimePicker_layout.HeightRequest = 80;
				endTimeLabel_layout.Padding = new Thickness(0, 20, 0, 0);
				EndDateTimePicker_layout.Padding = new Thickness(0, -20, 0, 0);
				EndDateTimePicker_layout.RowDefinitions = new RowDefinitionCollection()
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				};
			}

			else if (Device.OS == TargetPlatform.Android)
			{
				this.Padding = 20;
			}
        }
        public void OpenEditor(ScheduleAppointment appointment, DateTime date)
        {
            //button_layout.BackgroundColor = Color.FromHex("#e6e6e6");
            cancelButton.BackgroundColor = Color.FromHex("#e6e6e6");
            saveButton.BackgroundColor = Color.FromHex("#e6e6e6");
            subjectText.Placeholder = "Event Name";
            locationText.Placeholder = "Location";
            selectedAppointment = null;
            if (appointment != null)
            {
                selectedAppointment = appointment;
                selectedDate = date;
            }
            else
            {
                selectedDate = date;
            }
            UpdateEditor();


        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            ScheduleAppointmentModifiedEventArgs args = new ScheduleAppointmentModifiedEventArgs();
            args.Appointment = null;
            args.IsModified = false;
            OnAppointmentModified(args);
            this.IsVisible = false;
        }

        void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
            {
                selectedAppointment = new ScheduleAppointment();
            }

            selectedAppointment.Subject = subjectText.Text.ToString();
            selectedAppointment.StartTime = startDate_picker.Date.Add(startTime_picker.Time);
            selectedAppointment.EndTime = endDate_picker.Date.Add(endTime_picker.Time);
            selectedAppointment.Location = locationText.Text.ToString();

            ScheduleAppointmentModifiedEventArgs args = new ScheduleAppointmentModifiedEventArgs();
            args.Appointment = selectedAppointment;
            args.IsModified = true;
            OnAppointmentModified(args);

            this.IsVisible = false;

        }


        protected virtual void OnAppointmentModified(ScheduleAppointmentModifiedEventArgs e)
        {
            EventHandler<ScheduleAppointmentModifiedEventArgs> handler = AppointmentModified;
            if (handler != null)
            {
                handler(this, e);
            }

        }
        private void UpdateEditor()
        {
            if (selectedAppointment != null)
            {
                subjectText.Text = selectedAppointment.Subject.ToString();
                locationText.Text = selectedAppointment.Location;
                startDate_picker.Date = selectedAppointment.StartTime;
                startTime_picker.Time = new TimeSpan(selectedAppointment.StartTime.Hour, selectedAppointment.StartTime.Minute, selectedAppointment.StartTime.Second);
                endDate_picker.Date = selectedAppointment.EndTime;
                endTime_picker.Time = new TimeSpan(selectedAppointment.EndTime.Hour, selectedAppointment.EndTime.Minute, selectedAppointment.EndTime.Second);

            }
            else
            {
                subjectText.Text = "";
                locationText.Text = "";
                startDate_picker.Date = selectedDate;
                startTime_picker.Time = new TimeSpan(selectedDate.Hour, selectedDate.Minute, selectedDate.Second);
                endDate_picker.Date = selectedDate;
                endTime_picker.Time = new TimeSpan(selectedDate.Hour + 1, selectedDate.Minute, selectedDate.Second);
            }


        }
        public event EventHandler<ScheduleAppointmentModifiedEventArgs> AppointmentModified;
    }
    public class ScheduleAppointmentModifiedEventArgs : EventArgs
    {
        public ScheduleAppointment Appointment { get; set; }
        public bool IsModified { get; set; }
    }
}

