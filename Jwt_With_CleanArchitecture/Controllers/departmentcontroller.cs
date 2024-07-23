using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentEntity>>> GetAllDepartments()
        {
            try
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                return Ok(departments);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving the departments.");
            }
        }

        // GET: api/Departments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentEntity>> GetDepartmentById(int id)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving the department.");
            }
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<DepartmentEntity>> AddDepartment([FromBody] DepartmentEntity department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedDepartment = await _departmentService.AddDepartmentAsync(department);
                return CreatedAtAction(nameof(GetDepartmentById), new { id = addedDepartment.Id }, addedDepartment);
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the department.");
            }
        }

        // PUT: api/Departments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentEntity department)
        {
            if (id != department.Id)
            {
                return BadRequest("Department ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedDepartment = await _departmentService.UpdateDepartmentAsync(id, department);
                if (updatedDepartment == null)
                {
                    return NotFound();
                }
                return Ok(updatedDepartment);
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the department.");
            }
        }

        // DELETE: api/Departments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var success = await _departmentService.DeleteDepartmentAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the department.");
            }
        }
    }
}
