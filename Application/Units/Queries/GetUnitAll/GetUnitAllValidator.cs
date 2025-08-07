using Application.Resources.Queries.GetResourceAll;
using FluentValidation;

namespace Application.Units.Queries.GetUnitAll;

public class GetUnitAllValidator : AbstractValidator<GetResourceAllQry>
{
    public GetUnitAllValidator()
    {
    }
}