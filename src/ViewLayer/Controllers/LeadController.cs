using CRM.NexPolicy.src.DataLayer.Models.Lead;
using CRM.NexPolicy.src.ServiceLayer.LeadServices;
using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.NexPolicy.src.ViewLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost("CreateLead")]
        public async Task<IActionResult> CreateLead([FromBody] CreateLeadDto lead)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int newLeadId = await _leadService.RegisterLeadAsync(lead);
                return CreatedAtAction(nameof(GetLeadById), new { id = newLeadId }, newLeadId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // (opcional) Ejemplo de GET para CreatedAtAction
        [HttpGet("GetLeadById/{id:int}")]
        public async Task<IActionResult> GetLeadById(int id)
        {
            var lead = await _leadService.GetLeadWithAgentNameByIdAsync(id);
            if (lead == null)
                return NotFound(new { message = $"Lead with ID {id} not found." });

            return Ok(lead);
        }


        [HttpPut("UpdateLeadById/{id}")]
        public async Task<IActionResult> UpdateLead(int id, [FromBody] LeadModel updatedLead)
        {
            if (id != updatedLead.ID)
                return BadRequest("ID in URL does not match ID in payload.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool success = await _leadService.UpdateLeadAsync(updatedLead);
                if (!success)
                    return NotFound(new { message = "Lead not found." });

                return NoContent(); // HTTP 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", error = ex.Message });
            }
        }

        [HttpGet("GetAllLeads")]
        public async Task<IActionResult> GetAllLeads()
        {
            var leads = await _leadService.GetAllLeadsWithAgentAsync();
            return Ok(leads);
        }

    }
}
