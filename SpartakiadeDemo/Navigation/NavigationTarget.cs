namespace SpartakiadeDemo.Navigation
{
    public class NavigationTarget
    {
    }

    // lists/{id}
    public class ListTarget : NavigationTarget
    {
        public ListTarget(long listId)
        {
            ListId = listId;
        }

        public long ListId { get; private set; }
    }

    // tasks/{id}
    public class TaskTarget : NavigationTarget
    {
        public TaskTarget(long taskId)
        {
            TaskId = taskId;
        }

        public long TaskId { get; private set; }
    }

    // tasks/{id}/comments/{id}
    public class CommentTarget : NavigationTarget
    {
        public CommentTarget(long taskId, long commentId)
        {
            TaskId = taskId;
            CommentId = commentId;
        }

        public long TaskId { get; private set; }
        public long CommentId { get; private set; }
    }
}
