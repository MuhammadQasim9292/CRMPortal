using Application.DTMs.Search;
using Application.Interfaces;
using Common.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearch _roleService;
        public SearchController(ISearch roleService)
        {
            _roleService = roleService;
        }
       // [HttpGet]
        [HttpGet("{searchText}")]
        public async Task<ActionResult<ResponseVm>> GetValuebyId(string searchText)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var type = await _roleService.GetSearchtext(searchText);
            return Ok(type);
        }
    }
}
    