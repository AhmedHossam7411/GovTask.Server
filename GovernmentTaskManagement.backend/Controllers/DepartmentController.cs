using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GovernmentTaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService DepartmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            DepartmentService = _departmentService;
        }


        [HttpGet("AllDepartments")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var depts = await DepartmentService.GetAllDepartments();
            var dto = depts.ToDto();
            return Ok(dto);
        }


        [HttpGet("By-Id/{deptId}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentbyId([FromRoute]int deptId)
        {
            var departmentEntity = await DepartmentService.GetDepartmentById(deptId);

            if (departmentEntity == null)
            {
                return NotFound();
            }
            var dto = departmentEntity.ToDto();
            return Ok(dto);
        }

        [HttpGet("by-taskId")]
        public async Task<IActionResult> GetDeptByTaskId(int taskId)
        {
            var dept = await DepartmentService.GetDepartmentByTaskId(taskId);
            var dto = dept.ToDto();
            return Ok(dto);
        }

        [HttpGet("by-UserId")]
        public async Task<IActionResult> GetDeptByUserId(string userId)
        {
            var dept = await DepartmentService.GetDepartmentByUserId(userId);
            var dto = dept.ToDto();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment([FromRoute] int id, DepartmentDto dto)
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
        public async Task<IActionResult> DeleteDepartmentEntity([FromRoute] int id)
        {
            var departmentEntity = await DepartmentService.DeleteDepartment(id);
            if (departmentEntity == true)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
