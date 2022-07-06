namespace Akvelon.TaskTracker.Repository.Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public ProjectPriority ProjectPriority { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }

    public enum ProjectStatus
    {
        NotStarted = 0, 
        Active = 1, 
        Completed = 2
    }

    public enum ProjectPriority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}
