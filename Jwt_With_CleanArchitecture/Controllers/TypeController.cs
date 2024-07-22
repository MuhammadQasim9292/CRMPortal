using Application.Interfaces;
using Common.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
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
      
    }
}
     

