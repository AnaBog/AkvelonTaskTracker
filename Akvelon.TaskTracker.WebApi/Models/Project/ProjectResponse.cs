using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.WebApi.Models.Project.Get
{
    //This is the response we receive when GET object
    public class ProjectResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public ProjectPriority ProjectPriority { get; set; }

        public ProjectStatus ProjectStatus { get; set; }
    }
}
