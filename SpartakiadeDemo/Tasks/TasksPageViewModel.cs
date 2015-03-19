using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SpartakiadeDemo.Details;
using SpartakiadeDemo.Entities;

namespace SpartakiadeDemo.Tasks
{
    public class TasksPageViewModel : ObservableObject
    {
        public List<TaskViewModel> Tasks { get; set; }
        private TaskViewModel _selectedTask;
        public string ListTitle { get; set; }

        public TasksPageViewModel(long listId)
        {
            Tasks = (from task in Workspace.Current.Tasks.Where(x => x.ListId == listId)
                     select new TaskViewModel { Id = task.Id, Title = task.Title }).ToList();

            ListTitle = "Tasks from list " + Workspace.Current.Lists.FirstOrDefault(x => x.Id == listId).Title;
        }

        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (Equals(value, _selectedTask)) return;
                _selectedTask = value;
                NotifyOfPropertyChange(() => _selectedTask);

                ((Frame)Window.Current.Content).Navigate(typeof(TaskDetailsPage), _selectedTask.Id);
            }
        }
    }
}
