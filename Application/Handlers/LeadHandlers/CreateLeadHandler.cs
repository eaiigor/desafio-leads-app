using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.LeadCommands;
using desafio_leads.Domain.Entities;
using desafio_leads.Domain.Enums;
using desafio_leads.Infrastructure.Repositories.LeadRepository;
using MediatR;

namespace desafio_leads.Application.Handlers.LeadHandlers;

public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, LeadDTO>
{
    private readonly ILeadRepository _repository;
    private readonly IMapper _mapper;

    public CreateLeadHandler(ILeadRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LeadDTO> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = _mapper.Map<Lead>(request);
        lead.Status = ELeadStatus.Invited;
        var createdLead = await _repository.CreateLeadAsync(lead);
        return _mapper.Map<LeadDTO>(createdLead);
    }
}