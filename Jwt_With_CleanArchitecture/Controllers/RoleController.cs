using Application.DTMs.role;
using Application.DTMs.Types;
using Application.Interfaces;
using Common.Responses;
using Domain.Models.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _roleService;
        public RoleController(IRole roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllTypes()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _roleService.GetAllRole();
            return Ok(books);
        }
        [HttpGet("GetValueById/{id}")]
        public async Task<ActionResult<ResponseVm>> GetValuebyId(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var Role = await _roleService.GetRolebyId(id);
            return Ok(Role);
        }

        [HttpPost("Addtype")]
        public async Task<ActionResult<ResponseVm>> AddType([FromBody] RoleDTM Role)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _roleService.AddRole(Role);
            return Ok(response);
        }
        [HttpPost("UpdateType/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateType(long id, [FromBody] RoleDTM Role)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _roleService.UpdateRole(id, Role);
            return Ok(response);
        }
        [HttpPost("DeleteType/{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteType(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _roleService.DeleteRole(id);
            return Ok(response);
        }
    }
}
