using FluentValidation;

namespace Application.Units.Queries.GetUnitAll;

public class GetUnitAllValidator : AbstractValidator<GetUnitAllQry>
{
    public GetUnitAllValidator()
    {
        RuleFor(x => x.Status)
            .Must(s => s == "all" || s == "true" || s == "false");
    }
}