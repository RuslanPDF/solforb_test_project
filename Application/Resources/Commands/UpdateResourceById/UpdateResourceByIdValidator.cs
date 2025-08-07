using FluentValidation;

namespace Application.Resources.Commands.UpdateResourceById;

public class UpdateResourceByIdValidator : AbstractValidator<UpdateResourceByIdCmd>
{
    public UpdateResourceByIdValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Status);
    }
}