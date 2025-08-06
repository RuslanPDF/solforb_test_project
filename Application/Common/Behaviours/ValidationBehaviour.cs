using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseRequest
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var validation = await Task.WhenAll(
            _validators.Select(x => x.ValidateAsync(request, cancellationToken))
        );

        var fails = validation
            .Where(x => !x.IsValid)
            .SelectMany(x => x.Errors)
            .ToList();

        if (fails.Count == 0)
        {
            return await next();
        }

        throw new ValidationException(fails);
    }
}
