using Application.DTMs;
using Application.DTMs.Application.DTMs;
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
    public class LeaveBalanceController : ControllerBase
    {
        private readonly ILeaveBalanceService _leaveBalanceService;

        public LeaveBalanceController(ILeaveBalanceService leaveBalanceService)
        {
            _leaveBalanceService = leaveBalanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveBalance>>> GetAllLeaveBalances()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var leaveBalances = await _leaveBalanceService.GetAllLeaveBalances();
            return Ok(leaveBalances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseVm>> GetLeaveBalanceById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var leaveBalance = await _leaveBalanceService.GetLeaveBalanceById(id);
            return Ok(leaveBalance);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseVm>> AddLeaveBalance([FromBody] LeaveBalanceDTM leaveBalance)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _leaveBalanceService.AddLeaveBalance(leaveBalance);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateLeaveBalance(int id, [FromBody] LeaveBalanceDTM leaveBalance)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _leaveBalanceService.UpdateLeaveBalance(id, leaveBalance);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteLeaveBalance(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _leaveBalanceService.DeleteLeaveBalance(id);
            return Ok(response);
        }
    }
}
