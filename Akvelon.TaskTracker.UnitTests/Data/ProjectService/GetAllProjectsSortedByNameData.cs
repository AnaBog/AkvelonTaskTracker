using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;
using Bogus;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    //Prepare the data for the test
    public class GetAllProjectsSortedByNameData : TheoryData<string, string, List<Project>, List<ProjectModel>>
    {
        public GetAllProjectsSortedByNameData()
        {
            var faker = new Faker();


            //Unsorted projects
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

            //How projects should be sorted
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

            Add("Name", "asc", projects, sortedProjects);
        }
    }
}

