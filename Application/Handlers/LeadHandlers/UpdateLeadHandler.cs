using AutoMapper;
using desafio_leads.API.DTOs;
using desafio_leads.Application.Commands.LeadCommands;
using desafio_leads.Domain.Entities;
using desafio_leads.Domain.Enums;
using desafio_leads.Infrastructure.Repositories.LeadRepository;
using desafio_leads.Infrastructure.Services;
using MediatR;

namespace desafio_leads.Application.Handlers.LeadHandlers;

public class UpdateLeadHandler : IRequestHandler<UpdateLeadCommand, LeadDTO>
{
    private readonly ILeadRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public UpdateLeadHandler(ILeadRepository repository, IMapper mapper, IEmailService emailService)
    {
        _repository = repository;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<LeadDTO> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var leadFromRequest = _mapper.Map<Lead>(request);
        var lead = await _repository.GetLeadByIdAsync(leadFromRequest.Id);

        lead.Status = leadFromRequest.Status;

        if (lead.Status == ELeadStatus.Accepted)
        {
            await AcceptLead(lead);
        }

        var updatedLead = await _repository.UpdateLeadAsync(lead);
        return _mapper.Map<LeadDTO>(updatedLead);
    }

    private async Task AcceptLead(Lead lead)
    {
        lead.SalaryProposed = lead.Job.Salary;

        if (lead.SalaryProposed >= 500)
        {
            lead.SalaryProposed *= 0.9m;
        }

        await _emailService.SendEmailAsync("vendas@test.com", "Lead Aceito", "Lead aceito com desconto de 10%");
    }
}