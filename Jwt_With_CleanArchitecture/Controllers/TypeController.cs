using Application.DTMs.Types;
using Application.Interfaces;
using Common.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {

        private readonly IType _typeService;
        public TypeController(IType typeService)
        {
            _typeService = typeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetAllTypes()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _typeService.GetAllType();
            return Ok(books);
        }
        [HttpGet("GetValueById/{id}")]
        public async Task<ActionResult<ResponseVm>> GetValuebyId(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var type = await _typeService.GetTypebyId(id);
            return Ok(type);
        }

        [HttpPost("Addtype")]
        public async Task<ActionResult<ResponseVm>> AddType([FromBody] TypeDTM type)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _typeService.AddType(type);
            return Ok(response);
        }
        [HttpPost("UpdateType/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateType(long id, [FromBody]TypeDTM type)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _typeService.UpdateType(id, type);
            return Ok(response);
        }
        [HttpPost("DeleteType/{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteType(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _typeService.DeleteType(id);
            return Ok(response); 
        }

    }
}
     

