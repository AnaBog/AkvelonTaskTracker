using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.BusinessLogic.Contracts
{
    public interface IProjectService
    {
        Task<List<ProjectModel>> GetAllAsync(DateTime? startProject, DateTime? endProject, string? searchTerm, string? sortColumn, string? sortDirection, ProjectPriority? priority);

        Task<ProjectModel> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(ProjectModel projectModel);

        Task<Guid> UpdateAsync(Guid id, ProjectModel projectModel);

        void DeleteAsync(Guid id);

        Task<Guid> StartProjectAsync(Guid id);

        Task<Guid> EndProjectAsync(Guid id);
    }
}
