using Clinica.Application.UseCase.Commons.Bases;
using FluentValidation;
using MediatR;
using ValidationExceptions = Clinica.Application.UseCase.Commons.Exceptions.ValidationException;



namespace Clinica.Application.UseCase.Commons.Behavior
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationsResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationsResults
                    .Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .Select(x => new BaseError()
                    {
                        Propertyame = x.PropertyName,
                        ErrorMessage = x.ErrorMessage,
                    }).ToList();

                if (failures.Any())
                {
                    throw new ValidationExceptions(failures);
                }
            }

            return await next();

        }
    }

}
