using Application.Interfaces;
using Common.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerachController : ControllerBase
    {
        private readonly ISearch _roleService;
        public SerachController(ISearch roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GettextById/{serachtext}")]
        public async Task<ActionResult<ResponseVm>> GetValuebyId(string searchtext)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var type = await _roleService.GetSearchtext(searchtext);
            return Ok(type);
        }
    }
}
    