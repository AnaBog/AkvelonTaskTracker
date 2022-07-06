using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    public class GetAllData : TheoryData<List<Project>, List<ProjectModel>>
    {
        public GetAllData()
        {
            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    Name = "Ana Drugi Projekat"
                },
                 new Project()
                {
                    Name = "Ana Projekat"
                }
            };

            List<ProjectModel> expectedProjects = new List<ProjectModel>()
            {
                new ProjectModel()
                {
                    Name = "Ana Drugi Projekat"
                },
                new ProjectModel()
                {
                    Name = "Ana Projekat"
                }
            };

            Add(projects, expectedProjects);
        }
    }
}