using Akvelon.TaskTracker.BusinessLogic.Contracts;
using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Contracts;
using Akvelon.TaskTracker.Repository.Entities;
using AutoMapper;

namespace Akvelon.TaskTracker.BusinessLogic.Services
{
    internal class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _projectRepository = repository;

            _mapper = mapper;
        }

        public async Task<List<ProjectModel>> GetAllAsync(DateTime? startProject, DateTime? endProject, string? searchTerm, string? sortColumn, string? sortDirection, ProjectPriority? priority)
        {
            if (startProject > endProject)
            {
                throw new Exception("Start Date cannot be after the End Date");
            }

            var projects = await _projectRepository.GetAllAsync();

            var searchedProjects = projects.
                Where(x => searchTerm != null ? x.Name.ToLower().Contains(searchTerm.ToLower()) : true).
                Where(x => startProject != null ? x.StartDate == startProject : true).
                Where(x => endProject != null ? x.CompletedDate == endProject : true).
                Where(x => priority != null ? x.ProjectPriority == priority : true).ToList();

            var column = sortColumn ?? "name";
            var direction = sortDirection ?? "asc";

            #region Filtering/sorting

            if (column == "name" && direction == "asc")
            {
                searchedProjects = searchedProjects.OrderBy(x => x.Name).ToList();
            }

            if (column == "name" && direction == "desc")
            {
                searchedProjects = searchedProjects.OrderByDescending(x => x.Name).ToList();
            }

            if (column == "startDate" && direction == "asc")
            {
                searchedProjects = searchedProjects.OrderBy(x => x.StartDate).ToList();
            }

            if (column == "startDate" && direction == "desc")
            {
                searchedProjects = searchedProjects.OrderByDescending(x => x.StartDate).ToList();
            }

            if (column == "completeDate" && direction == "asc")
            {
                searchedProjects = searchedProjects.OrderBy(x => x.CompletedDate).ToList();
            }

            if (column == "completeDate" && direction == "desc")
            {
                searchedProjects = searchedProjects.OrderByDescending(x => x.CompletedDate).ToList();
            }

            if (column == "priority" && direction == "asc")
            {
                searchedProjects = searchedProjects.OrderBy(x => x.ProjectPriority).ToList();
            }

            if (column == "priority" && direction == "desc")
            {
                searchedProjects = searchedProjects.OrderByDescending(x => x.ProjectPriority).ToList();
            }

            if (column == "status" && direction == "asc")
            {
                searchedProjects = searchedProjects.OrderBy(x => x.ProjectStatus).ToList();
            }

            if (column == "status" && direction == "desc")
            {
                searchedProjects = searchedProjects.OrderByDescending(x => x.ProjectStatus).ToList();
            }

            #endregion Filtering/sorting

            var projectModels = new List<ProjectModel>();

            foreach (var project in projects)
            {
                projectModels.Add(_mapper.Map<ProjectModel>(project));
            }

            return projectModels;
        }

        public async Task<ProjectModel> GetByIdAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            var projectModel = _mapper.Map<ProjectModel>(project);

            return projectModel;
        }

        public async Task<Guid> CreateAsync(ProjectModel projectModel)
        {
            var project = _mapper.Map<Project>(projectModel);

            project.CompletedDate = null;
            project.StartDate = null;

            var projectId = await _projectRepository.CreateAsync(project);

            return projectId;
        }

        public async Task<Guid> UpdateAsync(Guid id, ProjectModel projectModel)
        {
            
            var projectToUpdate = await _projectRepository.GetByIdAsync(id);

            projectToUpdate.Name = projectModel.Name;
            projectToUpdate.ProjectPriority = projectModel.ProjectPriority;
            projectToUpdate.ProjectStatus = projectModel.ProjectStatus;

            var projectId = await _projectRepository.UpdateAsync(projectToUpdate);

            return projectId;
        }

        public void DeleteAsync(Guid id)
        {
            _projectRepository.DeleteAsync(id);
        }

        public async Task<Guid> StartProjectAsync(Guid id)
        {
            var projectId = await _projectRepository.StartProjectAsync(id);

            return projectId;
        }

        public async Task<Guid> EndProjectAsync(Guid id)
        {
            var projectId = await _projectRepository.EndProjectAsync(id);

            return projectId;
        }
    }
}
