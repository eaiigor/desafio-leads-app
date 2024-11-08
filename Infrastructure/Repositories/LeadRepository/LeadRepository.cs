using desafio_leads.Domain.Entities;
using desafio_leads.Domain.Enums;
using desafio_leads.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace desafio_leads.Infrastructure.Repositories.LeadRepository;

public class LeadRepository : ILeadRepository
{
    private readonly LeadsDbContext _ctx;

    public LeadRepository(LeadsDbContext ctx)
    {
        _ctx = ctx;
    }

    public Task<Lead> GetLeadByIdAsync(int id) => _ctx.Leads
        .Include(x => x.Job)
        .Include(x => x.Person)
        .FirstAsync(x => x.Id == id);

    public Task<List<Lead>> GetLeadsAsync(ELeadStatus status = ELeadStatus.Invited) => _ctx.Leads
        .Where(x => x.Status == status)
        .Include(x => x.Job)
        .Include(x => x.Person)
        .ToListAsync();

    public async Task<Lead> CreateLeadAsync(Lead lead)
    {
        await _ctx.Leads.AddAsync(lead);
        return await _ctx.SaveChangesAsync().ContinueWith(_ => lead);
    }

    public Task<Lead> UpdateLeadAsync(Lead lead)
    {
        _ctx.Entry(lead).State = EntityState.Modified;
        return _ctx.SaveChangesAsync().ContinueWith(_ => lead);
    }

    public async Task DeleteJobAsync(int id)
    {
        var job = await _ctx.Jobs.FirstAsync(x => x.Id == id);
        _ctx.Jobs.Remove(job);
        await _ctx.SaveChangesAsync();
    }
}