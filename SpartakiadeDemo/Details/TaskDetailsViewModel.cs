using System.Collections.Generic;
using System.Linq;
using SpartakiadeDemo.Entities;
using SpartakiadeDemo.Tasks;

namespace SpartakiadeDemo.Details
{
    public class TaskDetailsViewModel : ObservableObject
    {
        private TaskViewModel _task;
        public TaskViewModel Task { get { return _task; } }
        public List<CommentViewModel> Comments { get; set; }
        private CommentViewModel _selectedComment;

        public TaskDetailsViewModel(long taskId)
        {
            LoadData(taskId);
        }

        public TaskDetailsViewModel(long taskId, long commentId)
        {
            LoadData(taskId);
            _selectedComment = Comments.FirstOrDefault(x => x.Id == commentId);
        }

        private void LoadData(long taskId)
        {
            var task = Workspace.Current.Tasks.FirstOrDefault(x => x.Id == taskId);
            _task = new TaskViewModel { Id = taskId, Title = task.Title };

            Comments = (from comment in Workspace.Current.Comments.Where(x => x.TaskId == _task.Id)
                        select new CommentViewModel { Text = comment.Text, Id = comment.Id, }).ToList();
        }

        public CommentViewModel SelectedComment
        {
            get { return _selectedComment; }
            set
            {
                if (Equals(value, _selectedComment)) return;
                _selectedComment = value;
                NotifyOfPropertyChange(() => _selectedComment);

                // ((Frame)Window.Current.Content).Navigate(typeof(TaskDetailsPage), _selectedComment.Id);
            }
        }
    }
}
