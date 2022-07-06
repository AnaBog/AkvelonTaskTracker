using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.BusinessLogic.Services;
using Akvelon.TaskTracker.Repository.Contracts;
using Akvelon.TaskTracker.Repository.Entities;
using Akvelon.TaskTracker.UnitTests.Data.ProjectService;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Specialized;
using Moq;

namespace Akvelon.TaskTracker.UnitTests.Services
{
    public class ProjectServiceTests
    {
        //Moq makes a fake repository based on real one
        private readonly Mock<IProjectRepository> _projectRepositoryMock;

        private readonly Mock<IMapper> _mapperMock;

        public ProjectServiceTests()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        //This is a test for checking if the start date is greater that end date and should throw an exception
        [Theory]
        [ClassData(typeof(GetAllInvalidProjectDateData))]
        public async System.Threading.Tasks.Task GetAllAsync_ShouldThrowException_WhenStarProjectIsAfterEndProject(
            DateTime? startProject,
            DateTime? endProject,
            string? searchTerm,
            string? sortColumn,
            string? sortDirection,
            ProjectPriority? priority)
        {
            // Arrange
            var projectService = new ProjectService(_projectRepositoryMock.Object, _mapperMock.Object);

            // Act
            System.Threading.Tasks.Task Action() => projectService.GetAllAsync(startProject, endProject, searchTerm, sortColumn, sortDirection, priority);

            // Assert
            ExceptionAssertions<Exception> assertions = await FluentActions.Awaiting(Action).Should().ThrowAsync<Exception>();
            assertions.And.Message.Should().Be("Start Date cannot be after the End Date");
        }

        //This is a test for checking if the sort by name is working
        [Theory]
        [ClassData(typeof(GetAllProjectsSortedByNameData))]
        public async System.Threading.Tasks.Task GetAllAsync_ShouldReturnProjects_SortedByName(
            DateTime? startProject,
            DateTime? endProject,
            string? searchTerm,
            List<Project>? projects,
            List<ProjectModel>? sortedProjects,
            string? sortColumn = null,
            string? sortDirection = null,
            ProjectPriority? priority = null)
        {
            // Arrange
            var projectService = new ProjectService(_projectRepositoryMock.Object, _mapperMock.Object);

            //Mocking getting unsorted projects 
            _projectRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(projects);

            for (int i = 0; i < projects.Count; i++)
            {
                _mapperMock.Setup(x => x.Map<ProjectModel>(projects[i])).Returns(sortedProjects[i]);
            }

            // Act
            var result = await projectService.GetAllAsync(startProject, endProject, searchTerm, sortColumn, sortDirection, priority);

            // Assert
            result.Should().Equal(sortedProjects);
        }

        //This is a test for checking if the program will return all projects when fields are null
        [Theory]
        [ClassData(typeof(GetAllData))]
        public async System.Threading.Tasks.Task GetAllAsync_ShouldReturnEveryProject_WhenFieldsAreNull(
            DateTime? startProject,
            DateTime? endProject,
            List<Project> projects,
            List<ProjectModel> expectedProjects,
            string? searchTerm = null,
            string? sortColumn = null,
            string? sortDirection = null,
            ProjectPriority? priority = null)
        {
            // Arrange
            var projectService = new ProjectService(_projectRepositoryMock.Object, _mapperMock.Object);

            _projectRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(projects);

            for (int i = 0; i < projects.Count; i++)
            {
                _mapperMock.Setup(x => x.Map<ProjectModel>(projects[i])).Returns(expectedProjects[i]);
            }

            // Act
            var result = await projectService.GetAllAsync(startProject, endProject, searchTerm, sortColumn, sortDirection, priority);

            // Assert
            result.Should().Equal(expectedProjects);
        }

        //This test checks if the data has been updated
        [Theory]
        [ClassData(typeof(UpdateAsync))]
        public async System.Threading.Tasks.Task UpdateAsync_ShouldUpdateProject_WhenDataIsValid(
            Guid projectId, 
            ProjectModel projectModel, 
            Project project)
        {
            // Arrange
            var projectService = new ProjectService(_projectRepositoryMock.Object, _mapperMock.Object);

            // Act
            await projectService.UpdateAsync(project.Id, projectModel);
            
            _projectRepositoryMock.Setup(x => x.GetByIdAsync(projectId)).ReturnsAsync(project);

            // Assert
            project.Name.Should().Equals(projectModel.Name);
            project.StartDate.Should().NotBe(null);
            project.ProjectStatus.Should().Equals(projectModel.ProjectStatus);
        }
    }
}
