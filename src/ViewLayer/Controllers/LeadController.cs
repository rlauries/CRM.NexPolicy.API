using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.ServiceLayer.Lead;
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

        [HttpPost("createLead/")]
        public async Task<IActionResult> CreateLead([FromBody] LeadModel lead)
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
        [HttpGet("getLeadById/{id}")]
        public IActionResult GetLeadById(int id)
        {
            return Ok(new { Message = $"Dummy GET response for lead ID {id}" });
        }

        [HttpPut("UpdateLead/{id}")]
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

    }
}
