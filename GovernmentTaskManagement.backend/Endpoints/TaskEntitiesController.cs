using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using GovTaskManagement.Application.Services;

namespace GovernmentTaskManagement.Api.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskEntitiesController : ControllerBase
    {
        private readonly toolDbContext Context;
        private readonly TaskService TaskService;
        public TaskEntitiesController(toolDbContext _context, TaskService _taskService)
        {
            Context = _context;
            TaskService = _taskService;
        }

        // GET: api/TaskEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> GetTasks()
        {
            return await TaskService.GetAllTasks();
        }

        // GET: api/TaskEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTaskEntity(int id)
        {
            var taskEntity = await Context.Tasks.FindAsync(id);

            if (taskEntity == null)
            {
                return NotFound();
            }

            return taskEntity;
        }

        // PUT: api/TaskEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskEntity(int id, TaskEntity taskEntity)
        {
            if (id != taskEntity.Id)
            {
                return BadRequest();
            }

            Context.Entry(taskEntity).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskEntity>> PostTaskEntity(TaskEntity taskEntity)
        {
            Context.Tasks.Add(taskEntity);
            await Context.SaveChangesAsync();

            return CreatedAtAction("GetTaskEntity", new { id = taskEntity.Id }, taskEntity);
        }

        // DELETE: api/TaskEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskEntity(int id)
        {
            var taskEntity = await Context.Tasks.FindAsync(id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            Context.Tasks.Remove(taskEntity);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskEntityExists(int id)
        {
            return Context.Tasks.Any(e => e.Id == id);
        }
    }
}
