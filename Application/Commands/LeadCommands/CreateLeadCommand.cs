using desafio_leads.API.DTOs;
using desafio_leads.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace desafio_leads.Application.Commands.LeadCommands;

public class CreateLeadCommand : IRequest<LeadDTO>, ILeadsCommand
{
    public int JobId { get; set; }
    public int PersonId { get; set; }

    private class CreateLeadCommandValidator : AbstractValidator<CreateLeadCommand>
    {
        public CreateLeadCommandValidator()
        {
            RuleFor(x => x.JobId).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
        }
    }

    public ValidationResult Validate() => new CreateLeadCommandValidator().Validate(this);
}