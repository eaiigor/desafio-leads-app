using desafio_leads.API.DTOs;
using desafio_leads.Domain.Enums;
using desafio_leads.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace desafio_leads.Application.Commands.LeadCommands;

public class UpdateLeadCommand : IRequest<LeadDTO>, ILeadsCommand
{
    public int Id { get; set; }
    public ELeadStatus Status { get; set; }

    private class UpdateLeadCommandValidator : AbstractValidator<UpdateLeadCommand>
    {
        public UpdateLeadCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }

    public ValidationResult Validate() => new UpdateLeadCommandValidator().Validate(this);
}