using FluentValidation.Results;

namespace desafio_leads.Domain.Interfaces
{
    public interface ILeadsCommand
    {
        public ValidationResult Validate();
    }
}