using desafio_leads.API.DTOs;
using desafio_leads.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace desafio_leads.Application.Commands.PersonCommands;

public class UpdatePersonCommand : IRequest<PersonDTO>, ILeadsCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public ValidationResult Validate() => new UpdatePersonCommandValidator().Validate(this);

    class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}