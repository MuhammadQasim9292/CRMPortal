using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.TypeValue;
using Application.Interfaces;
using Common.CommonMethods;
using Common.Constants;
using Common.Responses;
using Dapper;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Services
{
    public class TypeValueService : ITypeValue
    {
        private readonly Database_context _context;
        public TypeValueService(Database_context db)
        {

            _context = db;
        }
        public async Task<ResponseVm> AddTypeValue(TypeValueDTM TypeValue)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var IsTypeExist = _context.TypeValue.FirstOrDefault(x => x.Value == TypeValue.Type_Value);
            var AddedType = new TypeValue
            {
                TypeId = TypeValue.Type_Id,
                Value = TypeValue.Type_Value
            };
          
                _context.TypeValue.Add(AddedType);
                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "TypeValue Added Successfully";
                response.ResponseData = AddedType;

            return response;
        }

        public async Task<ResponseVm> DeleteTypeValue(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string tablename = Tables.TypeValue_Table;
            var isDeleted = await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(), tablename, id);
            if (isDeleted == false)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete typeValue";

            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted typeValue";
                response.ResponseData = isDeleted;
            }
            return response;
        }

        public async Task<ResponseVm> GetAllTypeValue()
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string query = "SELECT t.TypeId,t.Value,(select Name from Types where Id=t.TypeId) from TypeValue t";
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
                else
                {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "Successfully founded type";
                    response.ResponseData = allTypes;
                }
                return response;
            }
        }

        public async Task<ResponseVm> GetTypeValuebyId(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var TypeValueObj = await _context.TypeValue.FindAsync(id);
            if (TypeValueObj == null)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "NOT founded type";
                response.ResponseData = null;
            }
        
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully founded type";
                response.ResponseData = TypeValueObj;
            }
            return response;
        }


        public async  Task<ResponseVm> UpdateTypeValue(int id, TypeValueDTM TypeValue)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var IsExist = _context.TypeValue.FirstOrDefault(x => x.Id ==id);

            if (IsExist != null)
            {

                IsExist.TypeId = TypeValue.Type_Id;
                IsExist.Value = TypeValue.Type_Value;

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

    }
}

