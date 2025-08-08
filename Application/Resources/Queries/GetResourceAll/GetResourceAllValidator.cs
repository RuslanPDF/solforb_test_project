using FluentValidation;

namespace Application.Resources.Queries.GetResourceAll;

public class GetResourceAllValidator : AbstractValidator<GetResourceAllQry>
{
    public GetResourceAllValidator()
    {
        RuleFor(x => x.Status)
            .Must(s => s == "all" || s == "true" || s == "false");
    }
}