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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class ListViewGettingStartedViewModel
    {
        #region Fields

        private ObservableCollection<ListViewShoppingCategoryInfo> categoryInfo;

        #endregion

        #region Constructor

        public ListViewGettingStartedViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewShoppingCategoryInfo> CategoryInfo
        {
            get { return categoryInfo; }
            set { this.categoryInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ShoppingCategoryInfoRepository cateoryinfo = new ShoppingCategoryInfoRepository();
            categoryInfo = cateoryinfo.GetCategoryInfo();
        }

        #endregion
    }

    public class ListViewGroupingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewContactsInfo> contactsInfo;

        #endregion

        #region Constructor

        public ListViewGroupingViewModel()
        {
            GenerateSource(100);
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewContactsInfo> ContactsInfo
        {
            get { return contactsInfo; }
            set { this.contactsInfo = value; }
        }

        #endregion

        #region ItemSource

        public void GenerateSource(int count)
        {
            ListViewContactsInfoRepository contactRepository = new ListViewContactsInfoRepository();
            contactsInfo = contactRepository.GetContactDetails(count);
        }

        #endregion
    }

    public class SortingFilteringViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ImageSource sortIcon;

        #endregion

        #region Constructor
        public SortingFilteringViewModel()
        {
            AddItemDetails();
            SortIcon = ImageSource.FromResource("SampleBrowser.Icons.ListView.SortIcon.png");
        }

        #endregion

        #region Properties

        public ObservableCollection<TaskInfo> Items
        {
            get;
            set;
        }

        public ImageSource SortIcon
        {
            get { return this.sortIcon; }
            set
            {
                this.sortIcon = value;
                OnPropertyChanged("SortIcon");
            }
        }

        #endregion

        #region Methods
        private void AddItemDetails()
        {
            Items = new ObservableCollection<TaskInfo>();
            var random = new Random();

            for (int i = 0; i < Features.Count(); i++)
            {
                var details = new TaskInfo()
                {
                    Title = Features[i],
                    Description = Description[i],
                    Tag = Tags[random.Next(0, 4)],
                };
                Items.Add(details);
            }
        }

        string[] Tags = new string[]
        {
            "Feature Implementation",
            "Bug Fixing",
            "Testing",
            "Design",
            "Post Processing"
        };

        string[] Features = new string[] 
        {
            "Swiping",
            "Pull To Refresh",
            "Selection in row header",
            "Multiple selection color",
            "Animating the selected row",
            "Long press event",
            "Double click event",
            "Header Template",
            "Orientation for ListView",
            "Multi-line text",
            "Item Border",
            "Item Style",
            "Scroll to a row/column index",
            "Group expand",
            "Enabling / disabling the bouncing behavior",
            "Group collapse",
            "Auto row height",
            "Drag and drop",
            "Auto item width",
        };

        string[] Description = new string[] {
            "Enables the users to swipe",
            "Pull To Refresh action refreshes the grid",
            "Apply selection using row header",
            "Apply different selection colors for different rows",
            "Add an animation upon selecting a row",
            "Users can listen to LongPresses in the listview",
            "Users can listen to double taps in the listview",
            "Load custom views as templates in header cells",
            "Orientation are vertical, horizontal",
            "Displays multi-line text for the record",
            "Enable item border",
            "Set the items style",
            "Scroll to a particular row and/or column index",
            "Expand groups in runtime",
            "Enable/disable the bouncing of the grid when over-scrolled",
            "Collapse groups in runtime",
            "Automatically adjusts the height of item to fit the content",
            "Rearrange the columns by dragging and dropping them",
            "Automatically adjusts the width of the item to fit the content",
        };

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public class ListViewSwipingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewInboxInfo> inboxInfo;

        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<ListViewInboxInfo> InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
        }

        #endregion
    }

    public class ListViewOrientationViewModel
    {
        #region Fields

        private ObservableCollection<PizzaInfo> pizzaInfo;
        private ObservableCollection<PizzaInfo> pizzaInfo1;
        
        #endregion

        #region Constructor

        public ListViewOrientationViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<PizzaInfo> PizzaInfo
        {
            get { return pizzaInfo; }
            set { this.pizzaInfo = value; }
        }

        public ObservableCollection<PizzaInfo> PizzaInfo1
        {
            get { return pizzaInfo1; }
            set { this.pizzaInfo1 = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            PizzaInfoRepository pizzainfo = new PizzaInfoRepository();
            pizzaInfo = pizzainfo.GetPizzaInfo();
            pizzaInfo1 = pizzainfo.GetPizzaInfo1();
        }

        #endregion
    }

    public class ListViewSelectionViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Musiqnfo> musicInfo;
        private ImageSource selectionEdit;
        private ImageSource selectionCancel;
        private string headerInfo;
        private string titleInfo;
        private bool isVisible;

        #endregion

        #region Constructor

        public ListViewSelectionViewModel()
        {
            GenerateSource();
            titleInfo = "Music Library";
            headerInfo = "";
            selectionEdit = ImageSource.FromResource("SampleBrowser.Icons.ListView.SelectionEdit.png");
            selectionCancel = ImageSource.FromResource("SampleBrowser.Icons.ListView.SelectionCancel.png");
        }

        #endregion

        #region Properties

        public ObservableCollection<Musiqnfo> MusicInfo
        {
            get { return musicInfo; }
            set { this.musicInfo = value; }
        }

        public string TitleInfo
        {
            get { return titleInfo; }
            set
            {
                if (titleInfo != value)
                {
                    titleInfo = value;
                    OnPropertyChanged("TitleInfo");
                }
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
        }

        public string HeaderInfo
        {
            get { return headerInfo; }
            set
            {
                if (headerInfo != value)
                {
                    headerInfo = value;
                    OnPropertyChanged("HeaderInfo");
                }
            }
        }

        public ImageSource SelectionEdit
        {
            get
            {
                return selectionEdit;
            }
            set
            {
                if (selectionEdit != value)
                {
                    selectionEdit = value;
                    OnPropertyChanged("SelectionEdit");
                }
            }
        }

        public ImageSource SelectionCancel
        {
            get
            {
                return selectionCancel;
            }
            set
            {
                if (selectionCancel != value)
                {
                    selectionCancel = value;
                    OnPropertyChanged("SelectionCancel");
                }
            }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            MusiqInfoRepository musiqinfo = new MusiqInfoRepository();
            musicInfo = musiqinfo.GetMusiqInfo();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
