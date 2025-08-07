using FluentValidation;

namespace Application.Units.Commands.CreateNewUnit;

public class CreateNewUnitValidator : AbstractValidator<CreateNewUnitCmd>
{
    public CreateNewUnitValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Status);
    }
}