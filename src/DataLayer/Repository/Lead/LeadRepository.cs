
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using CRM.NexPolicy.src.DataLayer.Models;
using CRM.NexPolicy.src.DataLayer.Repository.Lead;
using System;
using CRM.NexPolicy.src.DataLayer.Repository;


public class LeadRepository : ILeadRepository
{
    private readonly AppDbContext _dbContext;

    public LeadRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> InsertAsync(LeadModel lead)
    {
        _dbContext.Leads.Add(lead);
        await _dbContext.SaveChangesAsync();
        return lead.ID;
    }
    public async Task<LeadModel?> GetLeadByIdAsync(int leadId)
    {
        return await _dbContext.Leads
            .Include(l => l.Agent) // incluye datos del agente si están relacionados
            .FirstOrDefaultAsync(l => l.ID == leadId);
    }
    public async Task UpdateAsync(LeadModel lead)
    {
        _dbContext.Leads.Update(lead);
        await _dbContext.SaveChangesAsync();
    }


}
