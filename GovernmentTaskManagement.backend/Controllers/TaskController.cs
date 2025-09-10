using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;


namespace GovernmentTaskManagement.Api.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class TaskController : ControllerBase
    {
        
        private readonly ITaskService TaskService;
        
        public TaskController(ITaskService _taskService)
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
        [HttpGet("by-Creator/{creatorid}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByCreatorId(string id)   
        {
            var tasks = await TaskService.GetTasksByCreatorId(id);
            return Ok(tasks);
        }
        // GET: api/TaskEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id) { 
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(string name, TaskDto dto)
        {
            if (name != dto.Name)
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

        [HttpPost]
        public async Task<ActionResult<TaskDto>> PostTask(TaskDto dto)
        {
            var CreatorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var created = await TaskService.CreateTask(dto,CreatorId);
            return Ok(created);
        }

        // DELETE: api/TaskEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
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
