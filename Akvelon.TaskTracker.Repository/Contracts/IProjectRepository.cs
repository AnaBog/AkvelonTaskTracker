using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.Repository.Contracts
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(Project project);

        Task<Guid> UpdateAsync(Project project);

        void DeleteAsync(Guid id);

        Task<Guid> StartProjectAsync(Guid id);

        Task<Guid> EndProjectAsync(Guid id);
    }
}