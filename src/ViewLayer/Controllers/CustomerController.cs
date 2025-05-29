using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.ServiceLayer.Customer;
using CRM.NexPolicy.src.ServiceLayer.LeadServices;
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
        private readonly ILeadService _leadService;
        public CustomerController(ICustomerService customerService, ILeadService leadService)
        {
            _customerService = customerService;
            _leadService = leadService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customer = CustomerMapper.FromCreateDtoToCustomerModel(dto);
            var created = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = created.Id }, created);
        }
        
        [HttpPost("ConvertLeadToCustomer/{leadId:int}")]
        public async Task<IActionResult> ConvertLeadToCustomer(int leadId, [FromBody] LeadToCustomerDTO dto)
        {

            var customer = await _customerService.ConvertLeadIntoCustomerAsync(leadId, dto);
            if (customer == null)
                return BadRequest(new { message = "Lead not found or already converted." });

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpGet("GetCustomerById/{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customerDto = await _customerService.GetCustomerWithAgentNameByIdAsync(id);
            if (customerDto == null)
                return NotFound();

            return Ok(customerDto);
        }

        [HttpPut("UpdateCustomer/{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto dto)
        {

            var updated = await _customerService.UpdateCustomerAsync(dto);
            if (!updated)
                return StatusCode(500, new { message = "Failed to update customer." });

            return NoContent();
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersWithAgentNamesAsync();
            return Ok(customers);
        }

    }
}
