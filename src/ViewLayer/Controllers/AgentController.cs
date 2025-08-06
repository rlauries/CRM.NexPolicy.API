using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.ServiceLayer.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("CreateAgent")]
        public async Task<IActionResult> CreateAgent([FromBody] CreateAgentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _agentService.CreateAgentAsync(dto);
            return CreatedAtAction(nameof(GetAgentById), new { id = created.Id }, created);
        }

        // GET: api/agent/5
        [HttpGet("GetAgentById/{id:int}")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            var agentDto = await _agentService.GetAgentByIdAsync(id);
            if (agentDto == null)
                return NotFound();

            return Ok(agentDto);
        }

        // GET: api/agent
        [HttpGet("GetAllAgentByAgencyId/{id:int}")]
        public async Task<IActionResult> GetAllAgents(int id)
        {
            var agentDtos = await _agentService.GetAllAgentByAgencyIdAsync(id);
            return Ok(agentDtos);
        }


        [HttpPatch("UpdateProfile")]
        public async Task<IActionResult> PatchAgentProfile([FromBody] AgentPersonalInfoPatchDto dto)
        {
            var agentPatch = await _agentService.PatchAgentProfileByIdAsync(dto);
            return Ok(agentPatch);
        }


    }
}
