using Akvelon.TaskTracker.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.Repository.Contexts
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
