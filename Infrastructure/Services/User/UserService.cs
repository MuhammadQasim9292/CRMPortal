using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs;
using Application.Interfaces;
using Common.Responses;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Common.Token;


namespace Infrastructure.Services
{
    public class UserService : IUser
    { 
        private readonly IConfiguration _configuration;
        private readonly Database_context _context;
        public UserService(IConfiguration configuration, Database_context context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<ResponseVm> Login(UserLogin user)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;

            var validUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);
            // Return the result directly
            if(validUser!=null)
            {
                string tokenString = GenerateJwtToken(user);
                TokenVm.id = validUser.Id;
                TokenVm.email = validUser.Email;
                TokenVm.token = tokenString;
               
                response.ResponseCode = 200;
                response.ResponseMessage = "User logged in successfully";
                response.ResponseData = 
                    new
                    {
                        token = TokenVm.token,
                        userid = TokenVm.id,
                        email = TokenVm.email
                    };
                return response;
            }
            else
            {
                response.ResponseCode = 400;
                response.ResponseMessage = "Invalid username or password";
                return response;
            }
            
        }

      
        public async Task RegisterUser(UserCreate user)
        {
            try
            {
                var NewUser = new User
                {
                    Name = user.User_Name,
                    Email = user.Email,
                    Password = user.Password,
                    IsDeleted = false
                };
                await _context.Users.AddAsync(NewUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private string GenerateJwtToken(UserLogin user)
        {


            var authClaims = new List<Claim>
            {
                // Add your claims here
             new Claim("Name", user.Name),
             new Claim("Password", user.Password)
             // Add other claims as needed      
            };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                expires: DateTime.UtcNow.AddDays(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;

        }
    }

}
