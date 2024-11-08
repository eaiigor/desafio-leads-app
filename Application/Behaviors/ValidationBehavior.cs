using desafio_leads.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace desafio_leads.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILeadsCommand

    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Ops! Algo deu errado!", validationResult.Errors);
            }

            return await next();
        }
    }
}