using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.ServiceLayer.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.NexPolicy.src.ViewLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        // POST: api/agent
        [HttpPost]
        public async Task<IActionResult> CreateAgent([FromBody] CreateAgentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agent = new AgentModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                HomePhone = dto.HomePhone,
                CellPhone = dto.CellPhone,
                MiddleName = dto.MiddleName,
                Nickname = dto.Nickname,
                Title = dto.Title,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                SSN = dto.SSN,
                DriversLicenseNumber = dto.DriversLicenseNumber,
                LicenseNumber = dto.LicenseNumber,
                ContractedDate = dto.ContractedDate,
                IsActive = dto.IsActive,
                ManagerName = dto.ManagerName
                // Leads queda en null
            };

            var created = await _agentService.CreateAgentAsync(agent);
            return CreatedAtAction(nameof(GetAgentById), new { id = created.Id }, created);
        }


        // GET: api/agent/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            var agent = await _agentService.GetAgentByIdAsync(id);

            if (agent == null)
                return NotFound();

            var dto = new AgentResponseDto
            {
                Id = agent.Id,
                FullName = $"{agent.FirstName} {agent.LastName}",
                Email = agent.Email,
                LicenseNumber = agent.LicenseNumber,
                Leads = agent.Leads?
                    .Select(l => new LeadSummaryDto
                    {
                        Id = l.ID,
                        Name = $"{l.Name} {l.LastName}",
                        Email = l.Email
                    }).ToList() ?? new()
            };
            return Ok(dto);
        }
    }
}
