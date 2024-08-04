using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTMs;
using Application.Interfaces;
using Common.CommonMethods;
using Common.Constants;
using Common.Responses;
using Dapper;
using Domain.Models.Entities;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly Database_Context _context;

        public DistrictService(Database_Context db)
        {
            _context = db;
        }

        public async Task<ResponseVm> AddDistrict(DistrictDTM district)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var isDistrictExist = GetIsDistrictExist(district);

            if (isDistrictExist != null)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "District already exists";
                response.ResponseData = null;
                return response;
            }

            var addedDistrict = new District
            {
                Name = district.Name,
                AddedBy = "DefaultUser" // Assign a default or proper value here
            };

            _context.Districts.Add(addedDistrict);
            await _context.SaveChangesAsync();

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "District added successfully";
            response.ResponseData = addedDistrict;
            return response;
        }

        private District GetIsDistrictExist(DistrictDTM district)
        {
            return _context.Districts.FirstOrDefault(x => x.Name == district.Name);
        }

        public async Task<ResponseVm> UpdateDistrict(int ID, DistrictDTM district)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var isExist = _context.Districts.FirstOrDefault(x => x.ID == ID);

            if (isExist != null)
            {
                isExist.Name = district.Name;
                isExist.UpdatedBy = "DefaultUser"; // Assign a proper value here
                await _context.SaveChangesAsync();

                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Updated successfully";
                response.ResponseData = district;
            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "District not found";
                response.ResponseData = null;
            }
            return response;
        }

        public async Task<ResponseVm> DeleteDistrict(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string tableName = Table.Tables;
            var isDeleted = await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(), tableName, id);

            if (!isDeleted)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete district";
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted district";
                response.ResponseData = isDeleted;
            }
            return response;
        }

        public async Task<ResponseVm> GetAllDistricts()
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string query = "SELECT * FROM Districts";
            using (var connection = new SqlConnection(CommonOpertions.GetConnectionString()))
            {
                var districts = await connection.QueryAsync<dynamic>(query);
                var allDistricts = districts.ToList();
                if (allDistricts == null || !allDistricts.Any())
                {
                    response.ResponseCode = Responses.NotFoundCode;
                    response.ResponseMessage = "No districts found";
                    response.ResponseData = null;
                }
                else
                {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "Successfully retrieved districts";
                    response.ResponseData = allDistricts;
                }
                return response;
            }
        }

        public async Task<ResponseVm> GetDistrictById(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var district = await CommonOpertions.ExecuteStoredProceduresList("stpGetDistrictById", parameters, CommonOpertions.GetConnectionString());
            var districtData = district.ToList();

            if (districtData.Count == 0)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "District not found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "District found";
                response.ResponseData = districtData;
            }
            return response;
        }
    }
}
