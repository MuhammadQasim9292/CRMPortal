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
        Task<ResponseVm> GetTypeValuebyId(long id);
        Task<ResponseVm> AddTypeValue(TypeValueDTM TypeValue);
        Task<ResponseVm> UpdateTypeValue(long id, TypeValueDTM TypeValue);
        Task<ResponseVm> DeleteTypeValue(long id);
    }
}
