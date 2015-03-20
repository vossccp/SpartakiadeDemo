using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SpartakiadeDemo.Details;
using SpartakiadeDemo.Tasks;

namespace SpartakiadeDemo.Navigation
{
    public static class NavigationService
    {
        public static void Navigate(NavigationTarget target)
        {
            if (target is ListTarget)
            {
                Navigate("lists/" + (target as ListTarget).ListId);
            }
            else
            {
                ((Frame)Window.Current.Content).Navigate(typeof(TaskDetailsPage), target);
            }
        }

        public static void Navigate(string uri)
        {
            if (uri.StartsWith("sparta://"))
            {
                uri = uri.Substring(9);
            }

            if (uri.StartsWith("lists"))
            {
                ((Frame)Window.Current.Content).Navigate(typeof(TasksPage), uri.Split('/')[1]);
            }
            else if (uri.StartsWith("task"))
            {
                ((Frame)Window.Current.Content).Navigate(typeof(TaskDetailsPage), uri);
            }
        }
    }
}
