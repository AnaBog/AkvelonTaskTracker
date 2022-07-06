namespace Akvelon.TaskTracker.Repository.Entities
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? TaskDescription { get; set; }

        public TaskPriority TaskPriority { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }

    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }

    public enum TaskPriority
    {
        Low, Medium, High
    }
}
