using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SpartakiadeDemo.Navigation;

namespace SpartakiadeDemo.Tasks
{
    public sealed partial class TasksPage
    {
        public TasksPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = new TasksPageViewModel((ListTarget)e.Parameter);
            NavInfo.Text = e.Parameter + "";
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
