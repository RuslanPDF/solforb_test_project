using FluentValidation;

namespace Application.Units.Commands.UpdateUnitById;

public class UpdateUnitByIdValidator : AbstractValidator<UpdateUnitByIdCmd>
{
    public UpdateUnitByIdValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Status);
    }
}