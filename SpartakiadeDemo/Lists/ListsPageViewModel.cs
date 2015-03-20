using System.Collections.Generic;
using System.Linq;
using SpartakiadeDemo.Entities;
using SpartakiadeDemo.Navigation;

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

                NavigationService.Navigate(new ListTarget(_selectedList.Id));
            }
        }
    }
}
