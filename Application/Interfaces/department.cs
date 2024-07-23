// IDepartmentService.cs in Application/Interfaces
using Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync();
        Task<DepartmentEntity> GetDepartmentByIdAsync(int id);
        Task<DepartmentEntity> AddDepartmentAsync(DepartmentEntity department);
        Task<DepartmentEntity> UpdateDepartmentAsync(int id, DepartmentEntity department);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
