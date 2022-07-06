using Akvelon.TaskTracker.Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace Akvelon.TaskTracker.WebApi.Models.Project.Create
{
    //This is the object we send in POST, PUT 
    public class CreateProjectRequest
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public ProjectPriority ProjectPriority { get; set; }

        [Required]
        public ProjectStatus ProjectStatus { get; set; }
    }
}

