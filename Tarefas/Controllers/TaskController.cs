using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Repositories.Interfaces;

namespace Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> findAll()
        {
            List<TaskModel> tasks = await _taskRepository.findAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> findById(int id)
        {
            TaskModel task = await _taskRepository.findById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> create([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.create(taskModel);

            return Ok(task);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> update([FromBody] TaskModel taskModel, int id)
        {
            taskModel.id = id;
            TaskModel task = await _taskRepository.update(taskModel, id);

            return Ok(task);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> delete(int id)
        {
            bool delete = await _taskRepository.delete(id);

            return Ok(delete);
        }
    }
}

