using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.DataLayer.Models.Person;
using CRM.NexPolicy.src.DataLayer.Repository.AgentRepository;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;
using CRM.NexPolicy.src.ViewLayer.DTOs.Customer;
using CRM.NexPolicy.src.ViewLayer.DTOs.Lead;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRM.NexPolicy.src.ServiceLayer.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AgentModel> CreateAgentAsync(CreateAgentDto dto)
        {
            var agent = new AgentModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                AgencyId = dto.AgencyId,
                HomePhone = dto.HomePhone,
                CellPhone = dto.CellPhone,
                MiddleName = "",
                Nickname = "",
                Title = "",
                DateOfBirth = dto.DateOfBirth,
                GenderId = dto.GenderId,
                SSN = dto.SSN,
                DriversLicenseNumber = dto.DriversLicenseNumber,
                LicenseNumber = dto.LicenseNumber,

                // Dirección 🏠
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                ZipCode = dto.ZipCode,

                IsActive = true,
                IndividualStatusId = 1,
                ContractedDate = DateTime.UtcNow,
                
        // Leads queda en null
            };
            return await _agentRepository.CreateAsync(agent);
        }

        public async Task<AgentModel?> GetAgentByIdAsync(int id)
        {
            var agent = await _agentRepository.GetByIdAsync(id);
            if (agent == null) return null;

            return agent;
        }

        
        public async Task<List<AgentResponseDto>> GetAllAgentByAgencyIdAsync(int agencyId)
        {
            var agents = await _agentRepository.GetAllAgentyByAgencyIdAsync(agencyId);

            return agents.Select(agent => new AgentResponseDto
            {
                Id = agent.Id,
                FullName = $"{agent.FirstName} {agent.LastName}",
                Email = agent.Email,
                PhoneNumber = agent.CellPhone,
                LicenseNumber= agent.LicenseNumber,
            }).ToList();
        }

        public async Task<AgentModel> PatchAgentProfileByIdAsync(AgentPersonalInfoPatchDto dto)
        {
            var agent = await _agentRepository.PatchAgentProfileByIdAsync(dto);
            if (agent == null) return null;

            return agent;
            
        } 

    }
}
