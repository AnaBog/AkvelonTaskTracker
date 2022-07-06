using Akvelon.TaskTracker.Repository.Entities;
using TaskStatus = Akvelon.TaskTracker.Repository.Entities.TaskStatus;

namespace Akvelon.TaskTracker.BusinessLogic.Models.Task
{
    public class UpdateTaskModel
    {
        public string Name { get; set; }

        public string TaskDescription { get; set; }

        public TaskPriority TaskPriority { get; set; }

        public TaskStatus TaskStatus { get; set; }
    }
}
