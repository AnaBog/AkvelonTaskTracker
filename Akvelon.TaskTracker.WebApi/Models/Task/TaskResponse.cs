using Akvelon.TaskTracker.Repository.Entities;
using TaskStatus = Akvelon.TaskTracker.Repository.Entities.TaskStatus;

namespace Akvelon.TaskTracker.WebApi.Models.Task
{
    //This is the object we receive when use GET 
    public class TaskResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TaskDescription { get; set; }

        public TaskPriority TaskPriority { get; set; }

        public TaskStatus TaskStatus { get; set; }

        public Guid ProjectId { get; set; }
    }
}
