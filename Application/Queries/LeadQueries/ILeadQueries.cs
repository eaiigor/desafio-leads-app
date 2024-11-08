using desafio_leads.API.DTOs;
using desafio_leads.Domain.Enums;

namespace desafio_leads.Application.Queries.LeadQueries;

public interface ILeadQueries
{
    Task<LeadDTO> GetLeadByIdAsync(int id);
    Task<List<LeadDTO>> GetLeadsAsync(ELeadStatus status);
}