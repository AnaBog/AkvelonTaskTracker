using Akvelon.TaskTracker.BusinessLogic.Models.Task;

namespace Akvelon.TaskTracker.BusinessLogic.Contracts
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllAsync(Guid projectId);

        Task<TaskModel> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreateTaskModel taskModel);

        Task<Guid> UpdateAsync(Guid id, UpdateTaskModel taskModel);

        Task<Guid> ChangeProjectAsync(Guid taskId, Guid projectId);

        void Delete(Guid id);
    }
}
