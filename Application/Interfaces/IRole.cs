using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.Types;
using Common.Responses;
using Application.DTMs.role;
using Domain.Models.Entities;
namespace Application.Interfaces
{
    public interface IRole
          //public interface IRole<T>
    {
        Task<ResponseVm> GetAllRole();
        Task<ResponseVm> GetRolebyId(long id);
        Task<ResponseVm> AddRole(RoleDTM role);
        Task<ResponseVm> UpdateRole(long id, RoleDTM role);
        Task<ResponseVm> DeleteRole(long id);
      
    }
}
