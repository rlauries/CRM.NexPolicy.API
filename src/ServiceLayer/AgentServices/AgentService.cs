using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.DataLayer.Repository.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;
using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;

namespace CRM.NexPolicy.src.ServiceLayer.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AgentModel> CreateAgentAsync(AgentModel agent)
        {
            return await _agentRepository.CreateAsync(agent);
        }

        public async Task<AgentResponseDto?> GetAgentDtoByIdAsync(int id)
        {
            var agent = await _agentRepository.GetByIdAsync(id);
            if (agent == null) return null;

            return new AgentResponseDto
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
                    }).ToList() ?? new(),

                Customers = agent.Customers?
                    .Select(c => new CustomerSummaryDto
                    {
                        Id = c.Id,
                        FullName = $"{c.FirstName} {c.LastName}",
                        Email = c.Email
                    }).ToList() ?? new()
            };
        }

        // AgentService.cs
        public async Task<List<AgentResponseDto>> GetAllAgentDtosAsync()
        {
            var agents = await _agentRepository.GetAllAsync();

            return agents.Select(agent => new AgentResponseDto
            {
                Id = agent.Id,
                FullName = $"{agent.FirstName} {agent.LastName}",
                Email = agent.Email,
                LicenseNumber = agent.LicenseNumber,
                Leads = agent.Leads?.Select(l => new LeadSummaryDto
                {
                    Id = l.ID,
                    Name = $"{l.Name} {l.LastName}",
                    Email = l.Email
                }).ToList() ?? new(),

                Customers = agent.Customers?
                .Select(c => new CustomerSummaryDto
                {
                    Id = c.Id,
                    FullName = $"{c.FirstName} {c.LastName}",
                    Email = c.Email
                }).ToList() ?? new()
            }).ToList();
        }


    }
}
