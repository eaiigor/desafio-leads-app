using desafio_leads.Domain.Entities;
using desafio_leads.Domain.Enums;

namespace desafio_leads.Infrastructure.Repositories.LeadRepository;

public interface ILeadRepository
{
    Task<Lead> GetLeadByIdAsync(int id);
    Task<List<Lead>> GetLeadsAsync(ELeadStatus status);
    Task<Lead> CreateLeadAsync(Lead lead);
    Task<Lead> UpdateLeadAsync(Lead lead);
    Task DeleteJobAsync(int id);
}