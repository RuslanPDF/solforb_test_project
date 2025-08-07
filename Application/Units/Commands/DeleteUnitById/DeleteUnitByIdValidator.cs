using FluentValidation;

namespace Application.Units.Commands.DeleteUnitById;

public class DeleteUnitByIdValidator : AbstractValidator<DeleteUnitByIdCmd>
{
    public DeleteUnitByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotNull();
    }
}