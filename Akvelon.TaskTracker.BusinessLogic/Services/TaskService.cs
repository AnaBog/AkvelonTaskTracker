using Akvelon.TaskTracker.BusinessLogic.Contracts;
using Akvelon.TaskTracker.BusinessLogic.Models.Task;
using Akvelon.TaskTracker.Repository.Contracts;
using AutoMapper;

namespace Akvelon.TaskTracker.BusinessLogic.Services
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _taskRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<TaskModel>> GetAllAsync(Guid projectId)
        {
            var tasks = await _taskRepository.GetAllAsync(projectId);

            var taskList = new List<TaskModel>();

            foreach (var task in tasks)
            {
                taskList.Add(_mapper.Map<TaskModel>(task));
            }

            return taskList;
        }

        public async Task<TaskModel> GetByIdAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            var taskModel = _mapper.Map<TaskModel>(task);

            return taskModel;
        }

        public async Task<Guid> CreateAsync(CreateTaskModel taskModel)
        {
            var task = _mapper.Map<Repository.Entities.Task>(taskModel);

            var taskId = await _taskRepository.CreateAsync(task);

            return taskId;
        }

        public async Task<Guid> UpdateAsync(Guid id, UpdateTaskModel taskModel)
        {
            var task = _mapper.Map<Repository.Entities.Task>(taskModel);

            var taskId = await _taskRepository.UpdateAsync(id, task);

            return taskId;
        }

        public async Task<Guid> ChangeProjectAsync(Guid taskId, Guid projectId)
        {
            var movedTaskId = await _taskRepository.ChangeProjectAsync(taskId, projectId);

            return movedTaskId;
        }

        public void Delete(Guid id)
        {
            _taskRepository.Delete(id);
        }
    }
}
