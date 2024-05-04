using FluentValidation;
using MediatR;
using MKTournament.Application.Abstractions.Messaging;
using MKTournament.Application.Exceptions;
using ValidationException = MKTournament.Application.Exceptions.ValidationException;

namespace MKTournament.Application.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TRequest>
    where TRequest : IBaseCommand
{
    public async Task<TRequest> Handle(
        TRequest request,
        RequestHandlerDelegate<TRequest> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationErrors = validators
            .Select(validator => validator.Validate(context))
            .Where(validationResult => validationResult.Errors.Count != 0)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        if (validationErrors.Count != 0)
        {
            throw new ValidationException(validationErrors);
        }

        return await next();
    }
}