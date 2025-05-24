using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.ServiceLayer.Customer;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.NexPolicy.src.ViewLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {   
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("createCustomer/")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = created.Id }, created);
        }
        [HttpPost("convert/{leadId:int}")]
        public async Task<IActionResult> ConvertLeadToCustomer(int leadId)
        {
            var customer = await _customerService.ConvertLeadIntoCustomerAsync(leadId);
            if (customer == null)
                return BadRequest(new { message = "Lead not found or already converted." });

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }
        [HttpGet("GetCustomerById/{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
        [HttpPut("updateCustomer/{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _customerService.GetCustomerByIdAsync(id);
            if (existing == null)
                return NotFound(new { message = "Customer not found." });

            // Mapear valores del DTO al modelo existente
            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.Email = dto.Email;
            existing.HomePhone = dto.HomePhone;
            existing.CellPhone = dto.CellPhone;
            existing.Address = dto.Address;

            existing.PlanType = dto.PlanType;
            existing.EnrollmentDate = dto.EnrollmentDate ?? existing.EnrollmentDate;
            existing.AgentId = dto.AgentId;

            var updated = await _customerService.UpdateCustomerAsync(existing);
            if (!updated)
                return StatusCode(500, new { message = "Failed to update customer." });

            return NoContent();
        }

    }
}
