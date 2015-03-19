﻿using Windows.UI.Xaml.Navigation;

namespace SpartakiadeDemo.Lists
{
    public sealed partial class ListsPage
    {
        public ListsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = new ListsPageViewModel();
        }
    }
}
