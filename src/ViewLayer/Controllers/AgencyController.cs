using CRM.NexPolicy.src.ServiceLayer.AgencyServices;
using CRM.NexPolicy.src.ServiceLayer.UploadImageServices;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.NexPolicy.src.ViewLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        private readonly IUploadProfileImageService _uploadProfileImageService;

        public AgencyController(IAgencyService agencyService, IUploadProfileImageService uploadProfileImageService)
        {
            _agencyService = agencyService;
            _uploadProfileImageService = uploadProfileImageService;
        }

        [HttpGet("GetAllAgencies")]
        public async Task<IActionResult> GetAll()
        {
            var agencies = await _agencyService.GetAllAgenciesAsync();
            return Ok(agencies);
        }

        [HttpGet("GetAgencyById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agency = await _agencyService.GetAgencyByIdAsync(id);
            if (agency == null) return NotFound();
            return Ok(agency);
        }


        [HttpPut("UpdateAgency/{id:int}")]
        public async Task<IActionResult> UpdateAgency(int id, [FromBody] UpdateAgencyDto updatedAgency)
        {
        

            var result = await _agencyService.UpdateProfileAgencyAsync(id, updatedAgency);
            if (!result)
                return StatusCode(500, new { message = "Failed to update agency." });

            return NoContent();
        }

        [HttpPost("UploadAgencyLogo/{id}")]
        public async Task<IActionResult> UploadAgencyLogo(int id, IFormFile file)
        {
            try
            {
                var url = await _uploadProfileImageService.UploadImageAsync(id, "agency", file);
                
                return Ok(new { imageUrl = url });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
