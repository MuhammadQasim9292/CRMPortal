using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.Types;
using Application.DTMs.TypeValue;
using Common.Responses;

namespace Application.Interfaces
{
    public interface ITypeValue
    {
        Task<ResponseVm> GetAllTypeValue();
        Task<ResponseVm> GetTypeValuebyId(int id);
        Task<ResponseVm> AddTypeValue(TypeValueDTM TypeValue);
        Task<ResponseVm> UpdateTypeValue(int id, TypeValueDTM TypeValue);
        Task<ResponseVm> DeleteTypeValue(int id);
    }
}
