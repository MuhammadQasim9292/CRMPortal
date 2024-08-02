using Application.DTMs.dtm;
//using Application.DTMs.EmployeeDTM;
using Application.Interfaces;
using Common.Responses;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeJobDescriptionController : ControllerBase
    {
        private readonly IEmployeeJobDescriptionService _employeeJobDescriptionService;

        public EmployeeJobDescriptionController(IEmployeeJobDescriptionService employeeJobDescriptionService)
        {
            _employeeJobDescriptionService = employeeJobDescriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeJobDescription>>> GetAllEmployeeJobDescriptions()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var jobDescriptions = await _employeeJobDescriptionService.GetAllEmployeeJobDescriptions();
            return Ok(jobDescriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseVm>> GetEmployeeJobDescriptionById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var jobDescription = await _employeeJobDescriptionService.GetEmployeeJobDescriptionById(id);
            return Ok(jobDescription);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ResponseVm>> AddEmployeeJobDescription([FromBody] EmployeeDTM jobDescription)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _employeeJobDescriptionService.AddEmployeeJobDescription(jobDescription);
            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateEmployeeJobDescription(int id, [FromBody] EmployeeDTM jobDescription)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _employeeJobDescriptionService.UpdateEmployeeJobDescription(id, jobDescription);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteEmployeeJobDescription(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _employeeJobDescriptionService.DeleteEmployeeJobDescription(id);
            return Ok(response);
        }
    }
}
