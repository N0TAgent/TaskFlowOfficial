using Microsoft.AspNetCore.Mvc;
using TaskFlow.Core.Interfaces;
using TaskFlow.Core.Models;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> Get(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            return task;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TaskItem task)
        {
            await _taskRepository.AddTaskAsync(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskItem task)
        {
            if (id != task.Id)
                return BadRequest();

            await _taskRepository.UpdateTaskAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}
