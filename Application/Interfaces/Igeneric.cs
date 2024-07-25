using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.role;
using Common.Responses;
using Domain.Models.BaseEntitiyModels;

namespace Application.Interfaces
{
    public interface Igeneric<T>
    {
       //Task<T> GetAllRole();
       Task<T> GetRolebyId(long id);
        Task<T> AddRole(Object role);
         Task<T> UpdateRole(long id, T role);
        Task<T> DeleteRole(long id);
    }
}
