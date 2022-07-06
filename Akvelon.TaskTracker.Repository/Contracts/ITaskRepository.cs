namespace Akvelon.TaskTracker.Repository.Contracts
{
    public interface ITaskRepository
    {
        Task<List<Entities.Task>> GetAllAsync(Guid projectId);

        Task<Entities.Task> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(Entities.Task task);

        Task<Guid> UpdateAsync(Guid id, Entities.Task task);

        Task<Guid> ChangeProjectAsync(Guid taskId, Guid projectId);

        void Delete(Guid id);
    }
}
