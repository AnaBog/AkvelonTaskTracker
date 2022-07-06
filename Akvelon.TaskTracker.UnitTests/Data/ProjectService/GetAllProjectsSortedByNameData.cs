using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;
using Bogus;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    public class GetAllProjectsSortedByNameData : TheoryData<DateTime?, DateTime?, string, List<Project>, List<ProjectModel>>
    {
        public GetAllProjectsSortedByNameData()
        {
            var faker = new Faker();

            var startProject = DateTime.UtcNow;
            var endProject = DateTime.UtcNow.AddDays(1);

            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    Name = "Project Ana"
                },
                new Project()
                {
                    Name = "Ana Project"
                }
            };

            List<ProjectModel> sortedProjects = new List<ProjectModel>()
            {
                new ProjectModel()
                {
                    Name = "Ana Project"
                },
                new ProjectModel()
                {
                    Name = "Project Ana"
                }
            };

            Add(startProject, endProject, faker.Random.String(), projects, sortedProjects);
        }
    }
}

