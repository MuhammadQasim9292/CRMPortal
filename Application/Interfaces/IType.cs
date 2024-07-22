using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs;
using Application.DTMs.Types;
using Common.Responses;

namespace Application.Interfaces
{
    public interface IType
    {
        Task<ResponseVm> GetAllType();
        Task<ResponseVm> GetTypebyId(int id);
        Task<ResponseVm> AddType(TypeDTM type);
        Task<ResponseVm> UpdateType(int id,TypeDTM type);
        Task<ResponseVm> DeleteType(int id);
    }
}
