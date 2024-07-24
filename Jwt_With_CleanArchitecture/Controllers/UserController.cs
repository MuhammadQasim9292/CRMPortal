using Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Domain.Models.Entities;
using Application.DTMs;
using Common.Responses;
using Common.Constants;
using Application.DTMs.User;
using Azure;
using Infrastructure.Services;
using Application.DTMs.TypeValue;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userservice;
        private readonly IConfiguration _configuration;

        public UserController(IUser userservice, IConfiguration configuration)
        {
            _userservice = userservice;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ResponseVm> Login([FromBody] UserLoginDTM user)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            if (!ModelState.IsValid)
            {
               response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Invalid username or password";
                response.ResponseData= null;
                return response;
            }

            var validUser = await _userservice.Login(user);
            if (validUser !=null)
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "User logged in successfully";
                response.ResponseData = validUser.ResponseData;
                return response;
               
            }
            else
            {
                
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Invalid username or password";
                return response;
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserCreateDTM user)
        {
            await _userservice.RegisterUser(user);
            return Ok("User registered successfully");
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _userservice.DeleteUser(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllTypeValues()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _userservice.GetAllUsers();
            return Ok(books);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ResponseVm>> GetUserbyId(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var type = await _userservice.GetUserbyId(id);
            return Ok(type);
        }
        [HttpPost("UpdateUser/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateTypeValue(long id, [FromBody] UserLoginDTM type)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _userservice.UpdateUser(id, type);
            return Ok(response);
        }

    }
}
