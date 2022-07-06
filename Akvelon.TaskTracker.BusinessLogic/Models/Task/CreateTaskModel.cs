using Akvelon.TaskTracker.Repository.Entities;
using TaskStatus = Akvelon.TaskTracker.Repository.Entities.TaskStatus;

namespace Akvelon.TaskTracker.BusinessLogic.Models.Task
{
    public class CreateTaskModel
    {
        public string Name { get; set; }

        public string TaskDescription { get; set; }

        public TaskPriority TaskPriority { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public Guid ProjectId { get; set; }
    }
}
