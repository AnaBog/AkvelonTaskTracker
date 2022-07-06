using Akvelon.TaskTracker.BusinessLogic.Contracts;
using Akvelon.TaskTracker.BusinessLogic.Models.Task;
using Akvelon.TaskTracker.WebApi.Models.Task;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController
    {
        private readonly ITaskService _taskService;

        public TaskController(IMapper mapper, ITaskService taskService) : base(mapper)
        {
            _taskService = taskService;
        }

        //Gets all tasks of a selected project
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTasks([FromQuery] Guid projectId)
        {
            var tasks = await _taskService.GetAllAsync(projectId);

            var tasksResponseList = _mapper.Map<List<TaskResponse>>(tasks);

            return Ok(tasksResponseList);
        }

        //Gets a task by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var taskModel = await _taskService.GetByIdAsync(id);

            var task = _mapper.Map<TaskResponse>(taskModel);

            return Ok(task);
        }

        //Creates a new task
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest task)
        {
            var taskModel = _mapper.Map<CreateTaskModel>(task);

            var newTaskId = await _taskService.CreateAsync(taskModel);

            return CreatedAtAction("CreateTask", new { id = newTaskId }, newTaskId);
        }

        //Updates the selected task
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] UpdateTaskRequest task)
        {
            var updateTaskModel = _mapper.Map<UpdateTaskModel>(task);

            var updatedTaskId = await _taskService.UpdateAsync(id, updateTaskModel);

            return Ok(updatedTaskId);
        }

        //Moves task to another project
        [HttpPut("{taskId}/move-to-project")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ChangeProject([FromRoute] Guid taskId, [FromQuery] Guid projectId)
        {
            var updatedTaskId = await _taskService.ChangeProjectAsync(taskId, projectId);
            return Ok(updatedTaskId);
        }

        //Deletes the task with selected id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTask([FromRoute] Guid id)
        {
            _taskService.Delete(id);

            return Ok();
        }
    }
}
