using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SpartakiadeDemo.Details
{
    public sealed partial class TaskDetailsPage
    {
        public TaskDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = new TaskDetailsViewModel(e.Parameter + "");
            NavInfo.Text = e.Parameter + "";
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
