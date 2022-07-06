using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.BusinessLogic.Models.Project
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public ProjectPriority ProjectPriority { get; set; }

        public ProjectStatus ProjectStatus { get; set; }
    }
}
