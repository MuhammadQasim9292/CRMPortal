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

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _login;
        private readonly IConfiguration _configuration;

        public UserController(IUser login, IConfiguration configuration)
        {
            _login = login;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ResponseVm> Login([FromBody] UserLogin user)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            if (!ModelState.IsValid)
            {
               response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Invalid username or password";
                response.ResponseData= null;
                return response;
            }

            var validUser = await _login.Login(user);
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
        public async Task<ActionResult> RegisterUser(UserCreate user)
        {
            await _login.RegisterUser(user);
            return Ok("User registered successfully");
        }
    }
}
