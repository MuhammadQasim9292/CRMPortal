using Application.DTMs;
using Application.DTMs.Application.DTMs;
using Application.Interfaces;
using Common.Constants;
using Common.Responses;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly Database_Context _context;

        public LeaveBalanceService(Database_Context context)
        {
            _context = context;
        }

        public async Task<ResponseVm> AddLeaveBalance(LeaveBalanceDTM leaveBalance)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;

            // Check if the leave balance already exists
            var existingLeaveBalance = await _context.LeaveBalances
                .FirstOrDefaultAsync(x => x.EmployeeId == leaveBalance.EmployeeId &&
                                          x.LeaveTypeId == leaveBalance.LeaveTypeId &&
                                          x.FYId == leaveBalance.FYId);

            if (existingLeaveBalance != null)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Leave balance already exists";
                response.ResponseData = null;
                return response;
            }

            var newLeaveBalance = new LeaveBalance
            {
                EmployeeId = leaveBalance.EmployeeId,
                LeaveTypeId = leaveBalance.LeaveTypeId,
                Balance = leaveBalance.Balance,
                Availed = leaveBalance.Availed,
                FYId = leaveBalance.FYId,
                AddedBy = "DefaultUser" // Assign a default or proper value here
            };

            _context.LeaveBalances.Add(newLeaveBalance);
            await _context.SaveChangesAsync();

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Leave balance added successfully";
            response.ResponseData = newLeaveBalance;
            return response;
        }

        public async Task<ResponseVm> UpdateLeaveBalance(int id, LeaveBalanceDTM leaveBalance)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var existingLeaveBalance = await _context.LeaveBalances.FindAsync(id);

            if (existingLeaveBalance != null)
            {
                existingLeaveBalance.EmployeeId = leaveBalance.EmployeeId;
                existingLeaveBalance.LeaveTypeId = leaveBalance.LeaveTypeId;
                existingLeaveBalance.Balance = leaveBalance.Balance;
                existingLeaveBalance.Availed = leaveBalance.Availed;
                existingLeaveBalance.FYId = leaveBalance.FYId;
                existingLeaveBalance.UpdatedBy = "DefaultUser"; // Assign a proper value here

                await _context.SaveChangesAsync();

                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Updated successfully";
                response.ResponseData = existingLeaveBalance;
            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Leave balance not found";
                response.ResponseData = null;
            }
            return response;
        }

        public async Task<ResponseVm> DeleteLeaveBalance(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var leaveBalance = await _context.LeaveBalances.FindAsync(id);

            if (leaveBalance != null)
            {
                _context.LeaveBalances.Remove(leaveBalance);
                await _context.SaveChangesAsync();

                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted leave balance";
                response.ResponseData = leaveBalance;
            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Leave balance not found";
                response.ResponseData = null;
            }
            return response;
        }

        public async Task<ResponseVm> GetAllLeaveBalances()
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var leaveBalances = await _context.LeaveBalances.ToListAsync();

            if (leaveBalances == null || !leaveBalances.Any())
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "No leave balances found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully retrieved leave balances";
                response.ResponseData = leaveBalances;
            }
            return response;
        }

        public async Task<ResponseVm> GetLeaveBalanceById(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var leaveBalance = await _context.LeaveBalances.FindAsync(id);

            if (leaveBalance == null)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Leave balance not found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Leave balance found";
                response.ResponseData = leaveBalance;
            }
            return response;
        }
    }
}
