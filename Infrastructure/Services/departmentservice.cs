using Application;
using Application.Interfaces;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentContext _context;

        public DepartmentService(DepartmentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<DepartmentEntity> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<DepartmentEntity> AddDepartmentAsync(DepartmentEntity department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<DepartmentEntity> UpdateDepartmentAsync(int id, DepartmentEntity department)
        {
            if (id != department.Id)
            {
                return null;
            }

            _context.Entry(department).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> DepartmentExistsAsync(int id)
        {
            return await _context.Departments.AnyAsync(e => e.Id == id);
        }
    }
}
