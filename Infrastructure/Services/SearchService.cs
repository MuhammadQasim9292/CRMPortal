using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.Search;
using Application.Interfaces;
using Azure;
using Common.CommonMethods;
using Common.Constants;
using Common.Responses;
using Dapper;

namespace Infrastructure.Services
{
    public class SearchService : ISearch
    {
        public async Task<ResponseVm> GetSearchtext(string SearchText)
        { 
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            if (SearchText != null)
            {
                
                var parameters = new DynamicParameters();
                parameters.Add("@Name",SearchText);
                var name = await CommonOpertions.ExecuteStoredProceduresList("stpGetSearchValueById", parameters, CommonOpertions.GetConnectionString());
                if (name != null) {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseData= name;    
                }
            }
            return response;
        }
    }
}
