using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.BusinessLogic.Models.Project
{
    public class CreateProjectModel
    {
        public string Name { get; set; }

        public ProjectPriority ProjectPriority { get; set; }

        public ProjectStatus ProjectStatus { get; set; }
    }
}
