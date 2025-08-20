using GovTaskManagement.Application.Services;
using GovTaskManagement.Application.System_Collections.Dtos;
using GovTaskManagement.Application.System_Collections.Mappers;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using GovTaskManagement.Infrastructure.Repositories;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentTaskManagement.Api.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService DepartmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            DepartmentService = _departmentService;
        }

        // GET: api/DepartmentEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        { 
            var depts = await DepartmentService.GetAllDepartments();
            var dto = depts.ToDto();
            return Ok(dto);
        }

        // GET: api/DepartmentEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentbyId(int deptId)
        {
            var departmentEntity = await DepartmentService.GetDepartmentById(deptId);

            if (departmentEntity == null)
            {
                return NotFound();
            }
            var dto = departmentEntity.ToDto();
            return Ok(dto);
        }

        [HttpGet("by-taskId/{taskid}")]
        public async Task<IActionResult> GetDeptByTaskId(int taskId)
        {
            var dept = await DepartmentService.GetDepartmentByTaskId(taskId);
            var dto = dept.ToDto();
            return Ok(dto);
        }

        [HttpGet("by-UserId/{userid}")]
        public async Task<IActionResult> GetDeptByUserId(int userId)
        {
            var dept = await DepartmentService.GetDepartmentByUserId(userId);
            var dto = dept.ToDto();
            return Ok(dto);
        }

        // PUT: api/DepartmentEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var departmentEntity = dto.ToEntity(); 
                var updated = await DepartmentService.UpdateDepartment(departmentEntity);
                return NoContent();
            }

            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Department was updated or deleted by another user");
            }
            
        }

        // POST: api/DepartmentEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> PostDepartment(DepartmentDto dto)
        {
            var entity = dto.ToEntity();
            var created = await DepartmentService.CreateDepartment(entity);
            var finalDto = entity.ToDto();
            return Ok(finalDto);
        }

        // DELETE: api/DepartmentEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentEntity(int deptId)
        {
            var departmentEntity = await DepartmentService.DeleteDepartment(deptId);
            if (departmentEntity == true)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
