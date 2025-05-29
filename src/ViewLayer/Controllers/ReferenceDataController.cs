using CRM.NexPolicy.src.ServiceLayer.ReferenceDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.NexPolicy.src.ViewLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IReferenceDataService _service;

        public ReferenceDataController(IReferenceDataService service)
        {
            _service = service;
        }

        [HttpGet("lead-sources")]
        public async Task<IActionResult> GetLeadSources()
        {
            var result = await _service.GetLeadSourcesAsync();
            return Ok(result);
        }

        [HttpGet("lead-statuses")]
        public async Task<IActionResult> GetLeadStatuses()
        {
            var result = await _service.GetLeadStatusesAsync();
            return Ok(result);
        }

        [HttpGet("genders")]
        public async Task<IActionResult> GetGenderTypes()
        {
            var result = await _service.GetAllGenderTypesAsync();
            return Ok(result);
        }
    }

}
