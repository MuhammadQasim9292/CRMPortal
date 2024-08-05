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
using static Dapper.SqlMapper;


namespace Infrastructure.Services
{
    public class RoleService:IRole
    {
        private readonly Database_Context _context;
        private IGeneric<Role> _roleRepository;

        public RoleService(Database_Context context)
        {
            _context=context;
            _roleRepository = new GenericService<Role>(_context);
        }       
        public async  Task<ResponseVm> AddRole(RoleDTM role)
        {
        ResponseVm response = ResponseVm.GetResponseVmInstance;
            Role AddedType = new Role
            {
                Name = role.role_Name,
                Description = role.role_Description,
                IsDeleted = false,
                IsActive =false,

            };
            if (AddedType != null)
            {
                await _roleRepository.AddAsync(AddedType);
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "role Added Successfully";
                response.ResponseData = role;
            }
           else
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
            string tablename = Tables.Role_Table;

            var IsExist = _context.Role.FirstOrDefault(x => x.Id == id);
            var isDeleted = _roleRepository.SoftDelete(id, tablename);
            if (isDeleted == null)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete role";

            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted role";
                response.ResponseData = null;
            }
                     return response;
        }

        public async Task<ResponseVm> GetAllRole()
        {
           ResponseVm response = ResponseVm.GetResponseVmInstance;
            string tablename=Tables.Role_Table;
            var allTypes = await _roleRepository.GetAllAsync();
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

        public  async Task<ResponseVm> GetRolebyId(long id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var TypeValueData = await _roleRepository.GetByIdAsync(id);


            if (TypeValueData== null)
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
              var IsExist = _context.Role.FirstOrDefault(x => x.Id == id);

            if (IsExist != null)
            {

                IsExist.Name = role.role_Name;
                IsExist.Description = role.role_Description;        
                IsExist.UpdatedDate = DateTime.Now;
                await _roleRepository.UpdateAsync(IsExist);
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
            return response;
        }
    }
}
