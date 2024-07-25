using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTMs.dtm;
using Common.Responses;
using Domain.Models.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeJobDescriptionService
    {
        Task<IEnumerable<EmployeeJobDescription>> GetAllEmployeeJobDescriptions();
        Task<EmployeeJobDescription> GetEmployeeJobDescriptionById(int id);
        Task<ResponseVm> AddEmployeeJobDescription(EmployeeDTM jobDescription);
        Task<ResponseVm> UpdateEmployeeJobDescription(int id, EmployeeDTM jobDescription);
        Task<ResponseVm> DeleteEmployeeJobDescription(int id);
    }
}
