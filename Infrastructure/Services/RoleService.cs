using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.role;
using Application.Interfaces;
using Common.CommonMethods;
using Common.Constants;
using Common.Responses;
using Dapper;
using Domain.Models.BaseEntitiyModels;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Services
{
 //   public class RoleService<T> : IRole<T> where T:RoleService<T>
      public class RoleService:IRole
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
          
        }       
        public async  Task<ResponseVm> AddRole(RoleDTM role)
        {

        ResponseVm response = ResponseVm.GetResponseVmInstance;
           // var IsTypeExist = await _context.Role.FirstOrDefault(x => x.Name == role.role_Name);

            //if (IsTypeExist == null)
            {
                var AddedType = new Role
                {
                    Name = role.role_Name,
                    Description=role.role_Description
                };
                await _unitOfWork.Roles.AddAsync(AddedType);
                //generic.AddRole(AddedType);
                // _context.Role.Add(AddedType);
                // await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "role Added Successfully";
               // response.ResponseData = addedEntity;
            }
           // else
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Role Already Exist";
                response.ResponseData = null;

            }


            return response;
        }

        public async  Task<ResponseVm> DeleteRole(long id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
           /* string tablename = Tables.Role_Table;
            var IsExist = _context.Role.FirstOrDefault(x => x.Id == id);
            var isDeleted = await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(), tablename, id);
            if (isDeleted == false)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete role";

            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted role";
                response.ResponseData = isDeleted;
            }
           */
            return response;
        }

        public async Task<ResponseVm> GetAllRole()
        {
           ResponseVm response = ResponseVm.GetResponseVmInstance;
            string query = "SELECT Name,Description,IsActive from Role";
            using (var connection = new SqlConnection(CommonOpertions.GetConnectionString()))
            {
                var types = await connection.QueryAsync<dynamic>(query);
                var allTypes = types.ToList();
                if (allTypes == null)
                {
                    response.ResponseCode = Responses.NotFoundCode;
                    response.ResponseMessage = "NOT founded Role";
                    response.ResponseData = null;

                }
                else
                {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "Successfully founded Role";
                    response.ResponseData = allTypes;
                }
                return response;
            }
        }

        public  async Task<ResponseVm> GetRolebyId(long id) //heckit?
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var typevalue = await CommonOpertions.ExecuteStoredProceduresList("StpGetTypeRoleById", parameters, CommonOpertions.GetConnectionString());
            var TypeValueData = typevalue.ToList();
            if (TypeValueData.Count == 0)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Role not found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Role found";
                response.ResponseData = TypeValueData;
            }
            return response;
        }

        public async Task<ResponseVm> UpdateRole(long id, RoleDTM role)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
           /* var IsExist = _context.Role.FirstOrDefault(x => x.Id == id);

            if (IsExist != null)
            {

                IsExist.Name = role.role_Name;
                IsExist.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = " Updated Successfully";
                response.ResponseData = role;


            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Role not found";
                response.ResponseData = null;
            }
           */
            return response;
        }
    }
}
