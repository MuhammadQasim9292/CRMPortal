using Application.DTMs;
using Common.Responses;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDistrictService
    {
        Task<ResponseVm> GetAllDistricts();
        Task<ResponseVm> GetDistrictById(int id);
        Task<ResponseVm> AddDistrict(DistrictDTM district);
        Task<ResponseVm> UpdateDistrict(int id, DistrictDTM district);
        Task<ResponseVm> DeleteDistrict(int id);
    }
}
