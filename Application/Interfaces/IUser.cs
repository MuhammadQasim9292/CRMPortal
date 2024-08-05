using Application.DTMs;
using Common.Responses;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.User;
using Application.DTMs.TypeValue;
namespace Application.Interfaces
{
    public interface IUser
    {
        Task<ResponseVm> Login(UserLoginDTM user);
        Task RegisterUser(UserCreateDTM user);
        Task<ResponseVm> GetAllUsers();
        Task<ResponseVm> GetUserbyId(long id);
        Task<ResponseVm> UpdateUser(long id, UserLoginDTM TypeValue);
        Task<ResponseVm> DeleteUser(long id);
    }
}
