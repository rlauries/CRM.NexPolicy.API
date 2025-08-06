using CRM.NexPolicy.src.DataLayer.Models.Agent;
using CRM.NexPolicy.src.DataLayer.Repository;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRM.NexPolicy.src.DataLayer.Repository.AgentRepository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _dbContext;

        public AgentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AgentModel> CreateAsync(AgentModel agent)
        {
            _dbContext.Agents.Add(agent);
            await _dbContext.SaveChangesAsync();
            return agent;
        }

        public async Task<AgentModel?> GetByIdAsync(int id)
        {
            return await _dbContext.Agents
                .Include(a => a.IndividualStatus)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AgentModel>> GetAllAgentyByAgencyIdAsync(int agencyId)
        {
            var list = await _dbContext.Agents
                .Where(a => a.AgencyId == agencyId)
                .AsNoTracking()
                .ToListAsync();
            return list;
        }
        public async Task<AgentModel> PatchAgentProfileByIdAsync(AgentPersonalInfoPatchDto dto)
        {
            var agent = await _dbContext.Agents.FirstOrDefaultAsync(a => a.Id == dto.Id);
            
            // Actualizamos los campos solo si vienen con datos
            if (dto.IndividualStatusId.HasValue)
                agent.IndividualStatusId = dto.IndividualStatusId;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                agent.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Phone))
                agent.CellPhone = dto.Phone;

            if (!string.IsNullOrWhiteSpace(dto.Address))
                agent.Address = dto.Address;

            if (!string.IsNullOrWhiteSpace(dto.City))
                agent.City = dto.City;

            if (!string.IsNullOrWhiteSpace(dto.State))
                agent.State = dto.State;

            if (!string.IsNullOrWhiteSpace(dto.ZipCode))
                agent.ZipCode = dto.ZipCode;

            await _dbContext.SaveChangesAsync();
            return agent;
        }

    }
}
