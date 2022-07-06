using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    public class GetAllData : TheoryData<DateTime?, DateTime?, List<Project>, List<ProjectModel>>
    {
        public GetAllData()
        {
            var startProject = DateTime.UtcNow;
            var endProject = DateTime.UtcNow.AddDays(1);

            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    Name = "Ana"
                }
            };

            List<ProjectModel> expectedProjects = new List<ProjectModel>()
            {
                new ProjectModel()
                {
                    Name = "Ana"
                }
            };

            Add(startProject, endProject, projects, expectedProjects);
        }
    }
}