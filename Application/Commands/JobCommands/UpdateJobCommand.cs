using desafio_leads.API.DTOs;
using desafio_leads.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace desafio_leads.Application.Commands.JobCommands;

public class UpdateJobCommand : IRequest<JobDTO>, ILeadsCommand
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }

    private class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
    {
        public UpdateJobCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Salary).GreaterThan(0);
        }
    }

    public ValidationResult Validate() => new UpdateJobCommandValidator().Validate(this);
}