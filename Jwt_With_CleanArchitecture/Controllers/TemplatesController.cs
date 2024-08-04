
using Application.Interfaces;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        // GET: api/Templates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Template>>> GetAllTemplates()
        {
            try
            {
                var templates = await _templateService.GetAllTemplatesAsync();
                return Ok(templates);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving the templates.");
            }
        }

        // GET: api/Templates/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> GetTemplateById(int id)
        {
            try
            {
                var template = await _templateService.GetTemplateByIdAsync(id);
                if (template == null)
                {
                    return NotFound();
                }
                return Ok(template);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving the template.");
            }
        }

        // POST: api/Templates
        [HttpPost]
        public async Task<ActionResult<Template>> AddTemplate([FromBody] Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedTemplate = await _templateService.AddTemplateAsync(template);
                return CreatedAtAction(nameof(GetTemplateById), new { id = addedTemplate.ID }, addedTemplate);
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the template.");
            }
        }

        // PUT: api/Templates/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTemplate(int id, [FromBody] Template template)
        {
            if (id != template.ID)
            {
                return BadRequest("Template ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedTemplate = await _templateService.UpdateTemplateAsync(id, template);
                if (updatedTemplate == null)
                {
                    return NotFound();
                }
                return Ok(updatedTemplate);
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the template.");
            }
        }

        // DELETE: api/Templates/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            try
            {
                var success = await _templateService.DeleteTemplateAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the template.");
            }
        }
    }
}
