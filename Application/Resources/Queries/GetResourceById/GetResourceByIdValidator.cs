using FluentValidation;

namespace Application.Resources.Queries.GetResourceById;

public class GetResourceByIdValidator : AbstractValidator<GetResourceByIdQry>
{
    public GetResourceByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotNull();
    }
}