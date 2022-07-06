using Akvelon.TaskTracker.BusinessLogic.Contracts;
using Akvelon.TaskTracker.BusinessLogic.Services;
using Akvelon.TaskTracker.Repository.Contracts;
using Akvelon.TaskTracker.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Akvelon.TaskTracker.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
