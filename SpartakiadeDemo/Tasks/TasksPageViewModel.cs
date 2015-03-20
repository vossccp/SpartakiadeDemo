using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.StartScreen;
using SpartakiadeDemo.Entities;
using SpartakiadeDemo.Navigation;

namespace SpartakiadeDemo.Tasks
{
    public class TasksPageViewModel : ObservableObject
    {
        public List<TaskViewModel> Tasks { get; set; }
        private TaskViewModel _selectedTask;
        public string ListTitle { get; set; }
        public ICommand PinToStartCommand { get; set; }

        public TasksPageViewModel(ListTarget target)
        {
            Tasks = (from task in Workspace.Current.Tasks.Where(x => x.ListId == target.ListId)
                     select new TaskViewModel { Id = task.Id, Title = task.Title }).ToList();

            var list = Workspace.Current.Lists.FirstOrDefault(x => x.Id == target.ListId);
            ListTitle = "Tasks from list " + list.Title;

            PinToStartCommand = new DelegateCommand(async () =>
            {
                var logo = new Uri("ms-appx:///Assets/Logo.png");
                var secondaryTile = new SecondaryTile(Guid.NewGuid() + "", list.Title, "lists/" + target.ListId, logo, TileSize.Square150x150);
                secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
                await secondaryTile.RequestCreateAsync();
            });
        }

        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (Equals(value, _selectedTask)) return;
                _selectedTask = value;
                NotifyOfPropertyChange(() => _selectedTask);

                NavigationService.Navigate(new TaskTarget(_selectedTask.Id));
            }
        }
    }
}
