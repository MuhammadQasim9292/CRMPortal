using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class TemplateService : ITemplateService
    {
        private readonly Database_Context _context;

        public TemplateService(Database_Context context)
        {
            _context = context;
        }

        public async Task<ResponseVm> AddTemplateAsync(TemplateDTM templateDTM)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var addedTemplate = new Template
            {
                LetterTypeId = templateDTM.LetterTypeId,
               template = templateDTM.Template,
                LetterName = templateDTM.LetterName,
                AddedBy = "System",  // Or any other value
               
                UpdatedBy = "System",  // Or any other value
                
            };

            _context.Templates.Add(addedTemplate);
            await _context.SaveChangesAsync();

            response.ResponseCode = Responses.SuccessCode;
            response.ResponseMessage = "Template Added Successfully";
            response.ResponseData = addedTemplate;

            return response;
        }

        public Task<Template> AddTemplateAsync(Template template)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseVm> DeleteTemplateAsync(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
          // Ensure you have this constant defined
        var isDeleted = await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(),"", id);

            if (!isDeleted)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete template";
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted template";
                response.ResponseData = isDeleted;
            }

            return response;
        }

        public async Task<ResponseVm> GetAllTemplatesAsync()
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string query = "SELECT * FROM Templates";  // Adjust the query as needed

            using (var connection = new SqlConnection(CommonOpertions.GetConnectionString()))
            {
                var templates = await connection.QueryAsync<dynamic>(query);
                var allTemplates = templates.ToList();

                if (allTemplates == null || allTemplates.Count == 0)
                {
                    response.ResponseCode = Responses.NotFoundCode;
                    response.ResponseMessage = "No templates found";
                    response.ResponseData = null;
                }
                else
                {
                    response.ResponseCode = Responses.SuccessCode;
                    response.ResponseMessage = "Successfully retrieved templates";
                    response.ResponseData = allTemplates;
                }

                return response;
            }
        }

        public async Task<ResponseVm> GetTemplateByIdAsync(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var template = await CommonOpertions.ExecuteStoredProceduresList("stpGetTemplateById", parameters, CommonOpertions.GetConnectionString());
            var templateData = template.ToList();

            if (templateData.Count == 0)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Template not found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Template found";
                response.ResponseData = templateData;
            }

            return response;
        }

        public async Task<ResponseVm> UpdateTemplateAsync(int id, TemplateDTM templateDTM)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var existingTemplate = _context.Templates.FirstOrDefault(x => x.ID == id);

            if (existingTemplate != null)
            {
                existingTemplate.LetterTypeId = templateDTM.LetterTypeId;
                existingTemplate.template= templateDTM.Template;
                existingTemplate.LetterName = templateDTM.LetterName;
                existingTemplate.UpdatedBy = "System";  // Or any other value
               

                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Updated Successfully";
                response.ResponseData = existingTemplate;
            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Template not found";
                response.ResponseData = null;
            }

            return response;
        }

        public Task<Template> UpdateTemplateAsync(int id, Template template)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITemplateService.DeleteTemplateAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Template>> ITemplateService.GetAllTemplatesAsync()
        {
            throw new NotImplementedException();
        }

        Task<Template> ITemplateService.GetTemplateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
