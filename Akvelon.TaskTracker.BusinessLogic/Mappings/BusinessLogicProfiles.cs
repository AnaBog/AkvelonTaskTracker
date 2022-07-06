using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.BusinessLogic.Models.Task;
using Akvelon.TaskTracker.Repository.Entities;
using AutoMapper;

namespace Akvelon.TaskTracker.BusinessLogic.Mappings
{
    public static class AutoMapperBL
    {
        //Profiles for projects
        public class ProjectProfiles : Profile
        {
            public ProjectProfiles()
            {
                CreateMap<ProjectModel, Project>().ReverseMap();
                CreateMap<CreateProjectModel, Project>().ReverseMap();
            }
        }

        //Profiles for tasks
        public class TaskProfiles : Profile
        {
            public TaskProfiles()
            {
                CreateMap<TaskModel, Repository.Entities.Task>().ReverseMap();
                CreateMap<CreateTaskModel, Repository.Entities.Task>().ReverseMap();
                CreateMap<UpdateTaskModel, Repository.Entities.Task>().ReverseMap();
            }
        }
    }
}