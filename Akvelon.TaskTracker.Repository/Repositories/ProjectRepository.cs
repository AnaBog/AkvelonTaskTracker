using Akvelon.TaskTracker.Repository.Contexts;
using Akvelon.TaskTracker.Repository.Contracts;
using Akvelon.TaskTracker.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.Repository.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskTrackerDbContext _taskTrackerDbContext;

        public ProjectRepository(TaskTrackerDbContext taskTrackerDbContext)
        {
            _taskTrackerDbContext = taskTrackerDbContext;
        }
        
        public async Task<List<Project>> GetAllAsync() => await _taskTrackerDbContext.Projects.ToListAsync();

        public async Task<Project> GetByIdAsync(Guid id)
        {
            var project = await _taskTrackerDbContext.Projects.FindAsync(id);

            return project;
        }

        public async Task<Guid> CreateAsync(Project project)
        {
            var savedProject = _taskTrackerDbContext.Projects.Add(project).Entity;

            await _taskTrackerDbContext.SaveChangesAsync();

            return savedProject.Id;
        }

        public async Task<Guid> UpdateAsync(Project project)
        {
            _taskTrackerDbContext.Entry(project).State = EntityState.Modified;

            await _taskTrackerDbContext.SaveChangesAsync();

            return project.Id;
        }

        public void DeleteAsync(Guid id)
        {
            var project = new Project { Id = id };

            _taskTrackerDbContext.Entry(project).State = EntityState.Deleted;

            _taskTrackerDbContext.SaveChanges();
        }

        // Setting start and end of a project

        public async Task<Guid> StartProjectAsync(Guid id)
        {
            var project = await _taskTrackerDbContext.Projects.FirstOrDefaultAsync(t => t.Id == id);

            project.StartDate = DateTime.Now;

            _taskTrackerDbContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task<Guid> EndProjectAsync(Guid id)
        {
            var project = await _taskTrackerDbContext.Projects.FirstOrDefaultAsync(t => t.Id == id);

            project.CompletedDate = DateTime.Now;

            _taskTrackerDbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
