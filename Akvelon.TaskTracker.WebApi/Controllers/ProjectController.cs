using Akvelon.TaskTracker.BusinessLogic.Contracts;
using Akvelon.TaskTracker.BusinessLogic.Models.Project;
using Akvelon.TaskTracker.Repository.Entities;
using Akvelon.TaskTracker.WebApi.Models.Project.Create;
using Akvelon.TaskTracker.WebApi.Models.Project.Get;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IMapper mapper, IProjectService projectService) : base(mapper)
        {
            _projectService = projectService;
        }

        // Gets the list of all projects
        [HttpGet]
        [ProducesResponseType(typeof(List<ProjectResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(DateTime? startProject, DateTime? endProject, string? searchTerm, string? sortColumn, string? sortDirection, ProjectPriority? priority)
        {
            var projects = await _projectService.GetAllAsync(startProject, endProject, searchTerm, sortColumn, sortDirection, priority);

            var projectsResponse = _mapper.Map<List<ProjectResponse>>(projects);

            return Ok(projectsResponse);
        }



        // Gets a project by project id 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var project = await _projectService.GetByIdAsync(id);
            var projectDetails = _mapper.Map<ProjectResponse>(project);

            return Ok(projectDetails);
        }

        // Creates a new project
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest project)
        {
            var projectModel = _mapper.Map<ProjectModel>(project);

            var newProjectId = await _projectService.CreateAsync(projectModel);

            return CreatedAtAction("CreateProject", new { id = newProjectId }, newProjectId);
        }

        //Updates a project
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProject([FromRoute] Guid id, [FromBody] CreateProjectRequest project)
        {
            var projectModel = _mapper.Map<ProjectModel>(project);

            var updatedProjectId = await _projectService.UpdateAsync(id, projectModel);

            return Ok(updatedProjectId);
        }

        //Deletes a project by project id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProject([FromRoute] Guid id)
        {
            _projectService.DeleteAsync(id);

            return Ok();
        }

        //Endpoints for start and end project

        [HttpPut("{id}/start-project")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> StartProject([FromRoute] Guid id)
        {
            var startedProjectId = await _projectService.StartProjectAsync(id);

            return Ok(startedProjectId);
        }

        [HttpPut("{id}/end-project")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EndProject([FromRoute] Guid id)
        {
            var endedProjectId = await _projectService.EndProjectAsync(id);

            return Ok(endedProjectId);
        }
    }
}
