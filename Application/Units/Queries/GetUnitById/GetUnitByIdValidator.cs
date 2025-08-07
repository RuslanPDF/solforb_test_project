using FluentValidation;

namespace Application.Units.Queries.GetUnitById;

public class GetUnitByIdValidator : AbstractValidator<GetUnitByIdQry>
{
    public GetUnitByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotNull();
    }
}