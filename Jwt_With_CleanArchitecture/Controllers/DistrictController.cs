using Application.DTMs;
using Application.Interfaces;
using Common.Responses;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> GetAllDistricts()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var districts = await _districtService.GetAllDistricts();
            return Ok(districts);
        }

        [HttpGet("GetDistrictById/{id}")]
        public async Task<ActionResult<ResponseVm>> GetDistrictById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var district = await _districtService.GetDistrictById(id);
            return Ok(district);
        }

        [HttpPost("AddDistrict")]
        public async Task<ActionResult<ResponseVm>> AddDistrict([FromBody] DistrictDTM district)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _districtService.AddDistrict(district);
            return Ok(response);
        }

        [HttpPost("UpdateDistrict/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateDistrict(int id, [FromBody] DistrictDTM district)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _districtService.UpdateDistrict(id, district);
            return Ok(response);
        }

        [HttpPost("DeleteDistrict/{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteDistrict(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _districtService.DeleteDistrict(id);
            return Ok(response);
        }
    }
}
