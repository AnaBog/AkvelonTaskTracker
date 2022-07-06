using Akvelon.TaskTracker.Repository.Contexts;
using Akvelon.TaskTracker.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskTrackerDbContext _taskTrackerDbContext;

        public TaskRepository(TaskTrackerDbContext taskTrackerDbContext)
        {
            _taskTrackerDbContext = taskTrackerDbContext;
        }

        public async Task<List<Entities.Task>> GetAllAsync(Guid projectId)
        {
            var allTasks = await _taskTrackerDbContext.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();

            return allTasks;
        }

        public async Task<Entities.Task> GetByIdAsync(Guid id)
        {
            var task = await _taskTrackerDbContext.Tasks.FindAsync(id);

            return task;
        }

        public async Task<Guid> CreateAsync(Entities.Task task)
        {
            var taskNew = _taskTrackerDbContext.Tasks.Add(task).Entity;

            taskNew.TaskStatus = Entities.TaskStatus.ToDo;

            await _taskTrackerDbContext.SaveChangesAsync();

            return taskNew.Id;
        }

        public async Task<Guid> UpdateAsync(Guid id, Entities.Task task)
        {
            var updatedTask = await _taskTrackerDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            updatedTask.Name = task.Name;
            updatedTask.TaskDescription = task.TaskDescription;
            updatedTask.TaskPriority = task.TaskPriority;
            updatedTask.TaskStatus = task.TaskStatus;

            _taskTrackerDbContext.Entry(updatedTask).State = EntityState.Modified;

            await _taskTrackerDbContext.SaveChangesAsync();

            return updatedTask.Id;
        }

        public async Task<Guid> ChangeProjectAsync(Guid taskId, Guid projectId)
        {
            var taskToMove = await _taskTrackerDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            taskToMove.ProjectId = projectId;

            await _taskTrackerDbContext.SaveChangesAsync();

            return taskToMove.Id;
        }

        public void Delete(Guid id)
        {
            var task = new Entities.Task { Id = id };

            _taskTrackerDbContext.Entry(task).State = EntityState.Deleted;
            _taskTrackerDbContext.SaveChanges();
        }
    }
}
