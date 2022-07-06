using Akvelon.TaskTracker.Repository.Entities;
using System.ComponentModel.DataAnnotations;
using TaskStatus = Akvelon.TaskTracker.Repository.Entities.TaskStatus;

namespace Akvelon.TaskTracker.WebApi.Models.Task
{
    //This is the object we send in POST 
    public class CreateTaskRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required]
        public TaskPriority TaskPriority { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
    }
}
