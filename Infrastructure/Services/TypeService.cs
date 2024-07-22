using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.DTMs.Types;
using Application.Interfaces;
using Azure;
using Common.CommonMethods;
using Common.Constants;
using Common.Responses;
using Dapper;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Services
{
    public class TypeService : IType
    {
        private readonly Database_context _context;
        public TypeService(Database_context db)
        {

            _context = db;
        }
        public async Task<ResponseVm> AddType(TypeDTM type)
        {
        ResponseVm response = ResponseVm.GetResponseVmInstance;
            var IsTypeExist = _context.Types.FirstOrDefault(x => x.Name == type.Type_Name);
          
            if (IsTypeExist == null)
            {
                var AddedType = new Types
                {
                    Name = type.Type_Name,
                };
                _context.Types.Add(AddedType);
                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Type Added Successfully";
                response.ResponseData = AddedType;
            }
            else
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Type Already Exist";
                response.ResponseData = null;

            }

           
            return response;
        }

        public async Task<ResponseVm> DeleteType(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string tablename = Tables.Types_table;
            var isDeleted = await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(), tablename, id);
            if (isDeleted == false)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete type";

            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted type";
                response.ResponseData = isDeleted;
            }
            return response;
        }

        public async Task<ResponseVm> GetAllType()
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string query = "SELECT t.Name  FROM Types t ";
            using (var connection = new SqlConnection(CommonOpertions.GetConnectionString()))
            {
                var types = await connection.QueryAsync<dynamic>(query);
                var allTypes = types.ToList();
                if (allTypes == null) 
                {
                    response.ResponseCode = Responses.NotFoundCode;
                    response.ResponseMessage = "NOT founded type";
                    response.ResponseData = null;

                }
                else {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "Successfully founded type";
                    response.ResponseData = allTypes;
                }
                return response;
            }
        }

        public async Task<ResponseVm> GetTypebyId(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var Type= await _context.Types.FindAsync(id);
            if (Type == null)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "NOT founded type";
                response.ResponseData = null;
            }
            else {

                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully founded type";
                response.ResponseData = Type;
            }
            return response;
        }

        public async Task<ResponseVm> UpdateType(int id, TypeDTM type)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var IsExist = _context.Types.FirstOrDefault(x => x.Id == id);
   
            if (IsExist != null)
            {

                IsExist.Name = type.Type_Name;
                IsExist.UpdatedDate=DateTime.Now;   
                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = " Updated Successfully";
                response.ResponseData = type;


            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Type not found";
                response.ResponseData = null;
            }

            return response;
        }
    }
}
