using Application.DTMs.Types;
using Application.DTMs.TypeValue;
using Application.Interfaces;
using Common.Responses;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeValueController : ControllerBase
    {

        private readonly ITypeValue _typeService;
        public TypeValueController(ITypeValue typeValueService)
        {

            _typeService = typeValueService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeValue>>> GetAllTypeValues()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _typeService.GetAllTypeValue();
            return Ok(books);
        }
        [HttpGet("GetValueById/{id}")]
        public async Task<ActionResult<ResponseVm>> GetTypeValuebyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var type = await _typeService.GetTypeValuebyId(id);
            return Ok(type);
        }

        [HttpPost("Addtype")]
        public async Task<ActionResult<ResponseVm>> AddTypeValue([FromBody] TypeValueDTM type)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _typeService.AddTypeValue(type);
            return Ok(response);
        }
        [HttpPost("UpdateType/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateTypeValue (int id, [FromBody] TypeValueDTM type)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _typeService.UpdateTypeValue (id, type);
            return Ok(response);
        }
        [HttpPost("DeleteType/{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteTypeValue(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _typeService.DeleteTypeValue(id);
            return Ok(response);
        }



    }
}
