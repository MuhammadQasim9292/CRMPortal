using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTMs.dtm;
using Application.Interfaces;
using Common.Constants;
using Common.Responses;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeJobDescriptionService
    {
        private readonly Database_Context _context;

        public EmployeeService(Database_Context context)
        {
            _context = context;
        }

        public async Task<ResponseVm> AddEmployee(EmployeeDTM employeeDto)
        {
            var response = ResponseVm.GetResponseVmInstance;
            var newEmployee = new EmployeeJobDescription
            {
                Name = employeeDto.Name,
                Description = employeeDto.Description,
                DesignationId = employeeDto.DesignationId,
                IsDeleted = employeeDto.IsDeleted,
                AddedBy = employeeDto.AddedBy,
                AddedDate = employeeDto.AddedDate,
                UpdatedBy = employeeDto.UpdatedBy,
                UpdatedDate = employeeDto.UpdatedDate ?? DateTime.Now
            };

            _context.EmployeeJobDescriptions.Add(newEmployee);
            await _context.SaveChangesAsync();

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Employee added successfully";
            response.ResponseData = newEmployee;

            return response;
        }

        public Task<ResponseVm> AddEmployeeJobDescription(EmployeeDTM jobDescription)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseVm> DeleteEmployee(int id)
        {
            var response = ResponseVm.GetResponseVmInstance;
            var employee = await _context.EmployeeJobDescriptions.FindAsync(id);

            if (employee == null)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Employee not found";
                response.ResponseData = null;
                return response;
            }

            employee.IsDeleted = true;
            await _context.SaveChangesAsync();

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Employee deleted successfully";
            response.ResponseData = employee;

            return response;
        }

        public Task<ResponseVm> DeleteEmployeeJobDescription(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeJobDescription>> GetAllEmployeeJobDescriptions()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseVm> GetAllEmployees()
        {
            var response = ResponseVm.GetResponseVmInstance;
            var employees = await _context.EmployeeJobDescriptions
                .Where(e => !e.IsDeleted)
                .ToListAsync();

            if (employees == null || employees.Count == 0)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "No employees found";
                response.ResponseData = null;
                return response;
            }

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Employees retrieved successfully";
            response.ResponseData = employees;

            return response;
        }

        public async Task<ResponseVm> GetEmployeeById(int id)
        {
            var response = ResponseVm.GetResponseVmInstance;
            var employee = await _context.EmployeeJobDescriptions.FindAsync(id);

            if (employee == null || employee.IsDeleted)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Employee not found";
                response.ResponseData = null;
                return response;
            }

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Employee retrieved successfully";
            response.ResponseData = employee;

            return response;
        }

        public Task<EmployeeJobDescription> GetEmployeeJobDescriptionById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseVm> UpdateEmployee(int id, EmployeeDTM employeeDto)
        {
            var response = ResponseVm.GetResponseVmInstance;
            var existingEmployee = await _context.EmployeeJobDescriptions.FindAsync(id);

            if (existingEmployee == null)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Employee not found";
                response.ResponseData = null;
                return response;
            }

            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Description = employeeDto.Description;
            existingEmployee.DesignationId = employeeDto.DesignationId;
            existingEmployee.IsDeleted = employeeDto.IsDeleted;
            existingEmployee.UpdatedBy = employeeDto.UpdatedBy;
            existingEmployee.UpdatedDate = employeeDto.UpdatedDate ?? DateTime.Now;

            await _context.SaveChangesAsync();

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Employee updated successfully";
            response.ResponseData = existingEmployee;

            return response;
        }

        public Task<ResponseVm> UpdateEmployeeJobDescription(int id, EmployeeDTM jobDescription)
        {
            throw new NotImplementedException();
        }
    }
}
