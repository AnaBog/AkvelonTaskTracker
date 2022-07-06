using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.BusinessLogic.Models.Task;
using Akvelon.TaskTracker.WebApi.Models.Project.Create;
using Akvelon.TaskTracker.WebApi.Models.Project.Get;
using Akvelon.TaskTracker.WebApi.Models.Task;
using AutoMapper;

namespace Akvelon.TaskTracker.WebApi.Mappings
{
    //This is a mapper for project and task profiles and models
    public static class AutoMapperWebApi
    {
        public class ProjectProfiles : Profile 
        {
            public ProjectProfiles()
            {
                CreateMap<ProjectModel, ProjectResponse>();
                CreateMap<CreateProjectRequest, ProjectModel>();
            }
        }

        public class TaskProfiles : Profile
        {
            public TaskProfiles()
            {
                CreateMap<TaskModel, TaskResponse>();
                CreateMap<CreateTaskRequest, CreateTaskModel>();
                CreateMap<UpdateTaskRequest, UpdateTaskModel>();
            }
        }
    }
}