using Application.DTMs;
using Application.DTMs.Application.DTMs;
using Common.Responses;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILeaveBalanceService
    {
        Task<ResponseVm> GetAllLeaveBalances();
        Task<ResponseVm> GetLeaveBalanceById(int id);
        Task<ResponseVm> AddLeaveBalance(LeaveBalanceDTM leaveBalance);
        Task<ResponseVm> UpdateLeaveBalance(int id, LeaveBalanceDTM leaveBalance);
        Task<ResponseVm> DeleteLeaveBalance(int id);
    }
}
    