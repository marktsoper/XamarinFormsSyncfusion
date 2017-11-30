#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfKanban.XForms;

namespace SampleBrowser
{
    //ViewModel for GettingStarted sample

    public class KanbanGettingStartedViewModel
    {

        public ObservableCollection<KanbanModel> Cards { get; set; }

        public List<object> IList;

        public KanbanGettingStartedViewModel()
        {
            string path = "";
            if (App.Platform == Platforms.UWP)
                path = "Assets/KanbanIcons/";

            Cards = new ObservableCollection<KanbanModel>();

            IList = new List<object>() { "Open", "Test", "Close", "InProgress" };

            Cards.Add(
                new KanbanModel()
                {
                    ID = 1,
                    Title = "iOS - 1",
                    ImageURL = path + "Image8.png",
                    Category = "Open",
                    Description = "Analyze customer requirements",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Release Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Xamarin - 6",
                    ImageURL = path + "Image9.png",
                    Category = "Open",
                    Description = "Show the retrived data from the server in grid control",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "iOS - 3",
                    ImageURL = path + "Image10.png",
                    Category = "Open",
                    Description = "Fix the filtering issues reported in safari",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    ImageURL = path + "Image11.png",
                    Category = "Open",
                    Description = "Add input validation for editing",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 15,
                    Title = "Android - 15",
                    Category = "Open",
                    ImageURL = path + "Image12.png",
                    Description = "Arrange web meeting for cutomer requirement",
                    ColorKey = "Red",
                    Tags = new string[] { "Story", "Kanban" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Android - 3",
                    Category = "Code Review",
                    ImageURL = path + "Image13.png",
                    Description = "API Improvements",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Customer" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "UWP - 4",
                    ImageURL = path + "Image14.png",
                    Category = "Code Review",
                    Description = "Enhance editing functionality",
                    ColorKey = "Brown",
                    Tags = new string[] { "Story", "Kanban" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 9,
                    Title = "Xamarin - 9",
                    ImageURL = path + "Image15.png",
                    Category = "Code Review",
                    Description = "Improve application performance",
                    ColorKey = "Orange",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = path + "Image16.png",
                    Category = "In Progress",
                    Description = "Add responsive support to applicaton",
                    ColorKey = "Brown",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 17,
                    Title = "Xamarin - 17",
                    Category = "In Progress",
                    ImageURL = path + "Image17.png",
                    Description = "Fix the issues reported in IE browser",
                    ColorKey = "Brown",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 21,
                    Title = "Xamarin - 21",
                    Category = "In Progress",
                    ImageURL = path + "Image18.png",
                    Description = "Improve performance of editing functionality",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 19,
                    Title = "iOS - 19",
                    Category = "In Progress",
                    ImageURL = path + "Image19.png",
                    Description = "Fix the issues reported by the customer",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 8,
                    Title = "Android",
                    Category = "Code Review",
                    ImageURL = path + "Image20.png",
                    Description = "Check login page validation",
                    ColorKey = "Brown",
                    Tags = new string[] { "Feature" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 24,
                    Title = "UWP - 24",
                    ImageURL = path + "Image21.png",
                    Category = "In Progress",
                    Description = "Test editing functionality",
                    ColorKey = "Orange",
                    Tags = new string[] { "Feature", "Customer", "Release" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 20,
                    Title = "iOS - 20",
                    Category = "In Progress",
                    ImageURL = path + "Image22.png",
                    Description = "Fix the issues reported in data binding",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 12,
                    Title = "Xamarin - 12",
                    Category = "In Progress",
                    ImageURL = path + "Image23.png",
                    Description = "Test editing functionality",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    Category = "In Progress",
                    ImageURL = path + "Image24.png",
                    Description = "Check filtering validation",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = path + "Image25.png",
                    Category = "Closed",
                    Description = "Fix cannot open user's default database sql error",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Internal", "Release" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 14,
                    Title = "Android - 14",
                    Category = "Closed",
                    ImageURL = path + "Image26.png",
                    Description = "Arrange web meeting with customer to get login page requirement",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 15,
                    Title = "Xamarin - 15",
                    Category = "Closed",
                    ImageURL = path + "Image27.png",
                    Description = "Login page validation",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 16,
                    Title = "Xamarin - 16",
                    ImageURL = path + "Image28.png",
                    Category = "Closed",
                    Description = "Test the application in IE browser",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 20,
                    Title = "UWP - 20",
                    ImageURL = path + "Image29.png",
                    Category = "Closed",
                    Description = "Analyze stored procedure",
                    ColorKey = "Brown",
                    Tags = new string[] { "CustomSample", "Customer", "Incident" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 21,
                    Title = "Android - 21",
                    Category = "Closed",
                    ImageURL = path + "Image30.png",
                    Description = "Arrange web meeting with customer to get editing requirements",
                    ColorKey = "Orange",
                    Tags = new string[] { "Story", "Improvement" }
                }
            );

        }

    }

    //ViewModel for Customization sample

    public class KanbanCustomViewModel
    {

        public ObservableCollection<KanbanModel> Cards { get; set; }

        public KanbanCustomViewModel()
        {
            string path = "";
            if (App.Platform == Platforms.UWP)
                path = "Assets/KanbanIcons/";
            Cards = new ObservableCollection<KanbanModel>();

            Cards.Add(
                new KanbanModel()
                {
                    ID = 1,
                    Title = "Margherita",
                    ImageURL = path + "margherita.png",
                    Category = "Menu",
                    Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only.",
                    Tags = new string[] { "Cheese" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese Margherita",
                    ImageURL = path + "doublecheesemargherita.png",
                    Category = "Menu",
                    Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = path + "bucolicpie.png",
                    Category = "Menu",
                    Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
                    ImageURL = path + "bumpercrop.png",
                    Category = "Menu",
                    Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = path + "spiceoflife.png",
                    Category = "Menu",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = path + "verynicoise.png",
                    Category = "Menu",
                    Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 7,
                    Title = "Salad Daze",
                    ImageURL = path + "saladdaze.png",
                    Category = "Menu",
                    Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.",
                    Tags = new string[] { "Onions", "Jalapeno" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
                    ImageURL = path + "bumpercrop.png",
                    Category = "Ready to Serve",
                    Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = path + "spiceoflife.png",
                    Category = "Ready to Serve",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = path + "bucolicpie.png",
                    Category = "Door Delivery",
                    Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = path + "verynicoise.png",
                    Category = "Dining",
                    Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese Margherita",
                    ImageURL = path + "doublecheesemargherita.png",
                    Category = "Delivery",
                    Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );


        }

    }
}

