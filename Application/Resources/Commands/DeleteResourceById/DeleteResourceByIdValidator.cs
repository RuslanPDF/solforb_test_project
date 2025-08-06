using FluentValidation;

namespace Application.Resources.Commands.DeleteResourceById;

public class DeleteResourceByIdValidator : AbstractValidator<DeleteResourceByIdCmd>
{
    public DeleteResourceByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .NotNull();
    }
}