using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Application.Services;
using GovTaskManagement.Application.System_Collections.Dtos;
using Microsoft.Extensions.Caching.Memory;


namespace GovernmentTaskManagement.Api.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskEntitiesController : ControllerBase
    {
        
        private readonly ITaskService TaskService;
        
        public TaskEntitiesController(ITaskService _taskService)
        {
            
            TaskService = _taskService;
        }

        // GET: api/TaskEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await TaskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/TaskEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskEntity(int id)
        {
            var taskDto = await TaskService.GetTaskById(id);

            if (taskDto == null)
            {
                return NotFound();
            }

            return Ok(taskDto);
        }
        [HttpGet("by-document/{documentId}")]
        public async Task<ActionResult<TaskDto>> GetTaskByDocumentId(int documentId)
        {
            var taskDto = await TaskService.GetTaskByDocumentId(documentId);

            if (taskDto == null)
            {
                return NotFound();
            }

            return Ok(taskDto);
        }
        [HttpGet("by-department/{departmentId}")]
        public async Task<ActionResult<TaskDto>> GetTasksByDepartmentId(int departmentId)
        {
            var taskDto = await TaskService.GetTasksByDepartmentId(departmentId);

            if (taskDto == null)
            {
                return NotFound();
            }

            return Ok(taskDto);
        }

        // PUT: api/TaskEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskEntity(int id, TaskDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var updated = await TaskService.UpdateTask(dto);
                return NoContent();
            }

            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Task was updated or deleted by another user");
            }

        }


        // POST: api/TaskEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskDto>> PostTaskEntity(TaskDto dto)
        {
            
            var updated = await TaskService.CreateTask(dto);
            return Ok(updated);
        }

        // DELETE: api/TaskEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskEntity(int id)
        {
            var taskdto = await TaskService.DeleteTask(id);
            if (taskdto == true)
            {
                return Ok();
            }
          
            return NotFound();
        }

       
    }
}
