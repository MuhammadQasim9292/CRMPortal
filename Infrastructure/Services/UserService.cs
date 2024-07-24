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
using Application.DTMs.User;
using Common.Constants;
using Common.CommonMethods;
using Microsoft.Data.SqlClient;
using Dapper;


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

        public async  Task<ResponseVm> DeleteUser(long id)
        { 
               ResponseVm response = ResponseVm.GetResponseVmInstance;
         
                var Employee = await _context.Users.FindAsync(id);
                if (Employee != null)
                {
                    _context.Users.Remove(Employee);
                    await _context.SaveChangesAsync();
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "User deleted successfully";
                    response.ResponseData = Employee;
                    return response;


                }
                else
                {
                    response.ResponseCode =Responses.SuccessCode;
                    response.ResponseMessage = "User deleted successfully";
                    response.ResponseData = Employee;
                    return response;

                }
            }
     

        public async  Task<ResponseVm> GetAllUsers()
        {

            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string query = "SELECT t.Name,t.Email  FROM Users t ";
            using (var connection = new SqlConnection(CommonOpertions.GetConnectionString()))
            {
                var types = await connection.QueryAsync<dynamic>(query);
                var allTypes = types.ToList();
                if (allTypes == null)
                {
                    response.ResponseCode = Responses.NotFoundCode;
                    response.ResponseMessage = "NOT founded user";
                    response.ResponseData = null;

                }
                else
                {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "Successfully founded user";
                    response.ResponseData = allTypes;
                }
                return response;
            }
        }

        public  async Task<ResponseVm> GetUserbyId(long id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var typevalue = await CommonOpertions.ExecuteStoredProceduresList("StpGetUserById", parameters, CommonOpertions.GetConnectionString());
            var TypeValueData = typevalue.ToList();
            if (TypeValueData.Count == 0)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "user not found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "user found";
                response.ResponseData = TypeValueData;
            }
            return response;
        }

        public async Task<ResponseVm> Login(UserLoginDTM user)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;

            var validUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);
            // Return the result directly
            if(validUser!=null)
            {
               string tokenString = GenerateJwtToken();
                TokenVm.id = validUser.Id;
                TokenVm.email = validUser.Email;
                TokenVm.token = tokenString;
               
                response.ResponseCode = Responses.SuccessCode;
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
                response.ResponseCode =Responses.NotFoundCode;
                response.ResponseMessage = "Invalid username or password";
                return response;
            }

                

            
            
        }

      
        public async Task RegisterUser(UserCreateDTM user)
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
                throw new Exception(user.Email);
            }
        }

        public async  Task<ResponseVm> UpdateUser(long id, UserLoginDTM TypeValue)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
              var IsExist = _context.Users.FirstOrDefault(x => x.Id == id);

             if (IsExist != null)
             {

                IsExist.Name = TypeValue.Name;
                 IsExist.UpdatedDate=DateTime.Now;   
                 await _context.SaveChangesAsync();
                 response.ResponseCode = Responses.SuccessCode;
                 response.ResponseMessage = " Updated Successfully";
                 response.ResponseData = TypeValue;


             }
             else
             {
                 response.ResponseCode = Responses.NotFoundCode;
                 response.ResponseMessage = "Type not found";
                 response.ResponseData = null;
             }
            return response;
        }

        private string GenerateJwtToken()

        {
            try
            {
                var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                  _configuration["Jwt:Issuer"],
                                                  null,
                                                  expires: DateTime.Now.AddMinutes(120),
                                                  signingCredentials: credentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    }

}
