using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;
using AutoBogus;
using Bogus;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    public class UpdateAsync : TheoryData<Guid, ProjectModel, Project>
    {
        public UpdateAsync()
        {
            var projectId = Guid.NewGuid();

            Faker<ProjectModel> projectModel = new AutoFaker<ProjectModel>()
                .RuleFor(x => x.Id, () => projectId)
                .RuleFor(x => x.Name, x => "Ana's Project")
                .RuleFor(x => x.StartDate, x => null)
                .RuleFor(x => x.CompletedDate, x => null)
                .RuleFor(x => x.ProjectPriority, ProjectPriority.High)
                .RuleFor(x => x.ProjectStatus, ProjectStatus.NotStarted);

            Faker<Project> project = new AutoFaker<Project>()
                .RuleFor(x => x.Id, () => projectId)
                .RuleFor(x => x.Name, x => "Ana")
                .RuleFor(x => x.StartDate, x => null)
                .RuleFor(x => x.CompletedDate, x => null)
                .RuleFor(x => x.ProjectPriority, ProjectPriority.Low)
                .RuleFor(x => x.ProjectStatus, ProjectStatus.NotStarted);

            var dataFaker = new Faker();

            Add(projectId, projectModel.Generate(), project.Generate());
        }
    }
}

