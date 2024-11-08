using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Domain.Enums;
using desafio_leads.Infrastructure.Repositories.LeadRepository;

namespace desafio_leads.Application.Queries.LeadQueries;

public class LeadQueries : ILeadQueries
{
    private readonly ILeadRepository _leadRepository;
    private readonly IMapper _mapper;

    public LeadQueries(ILeadRepository leadRepository, IMapper mapper)
    {
        _leadRepository = leadRepository;
        _mapper = mapper;
    }


    public async Task<LeadDTO> GetLeadByIdAsync(int id)
    {
        var lead = await _leadRepository.GetLeadByIdAsync(id);
        return _mapper.Map<LeadDTO>(lead);
    }

    public async Task<List<LeadDTO>> GetLeadsAsync(ELeadStatus status)
    {
        var leads = await _leadRepository
            .GetLeadsAsync(status);
        return _mapper.Map<List<LeadDTO>>(leads);
    }
}