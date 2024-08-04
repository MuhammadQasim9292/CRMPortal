using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITemplateService
    {
        Task<IEnumerable<Template>> GetAllTemplatesAsync();
        Task<Template> GetTemplateByIdAsync(int id);
        Task<Template> AddTemplateAsync(Template template);
        Task<Template> UpdateTemplateAsync(int id, Template template);
        Task<bool> DeleteTemplateAsync(int id);
    }
}
