using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SpartakiadeDemo.Entities;
using SpartakiadeDemo.Tasks;

namespace SpartakiadeDemo.Lists
{
    public class ListsPageViewModel : ObservableObject
    {
        private ListViewModel _selectedList;
        public List<ListViewModel> Lists { get; set; }

        public ListsPageViewModel()
        {
            Lists = (from list in Workspace.Current.Lists
                     select new ListViewModel { Id = list.Id, Title = list.Title }).ToList();
        }

        public ListViewModel SelectedList
        {
            get { return _selectedList; }
            set
            {
                if (Equals(value, _selectedList)) return;
                _selectedList = value;
                NotifyOfPropertyChange(() => SelectedList);

                ((Frame)Window.Current.Content).Navigate(typeof(TasksPage), _selectedList.Id);
            }
        }
    }
}
