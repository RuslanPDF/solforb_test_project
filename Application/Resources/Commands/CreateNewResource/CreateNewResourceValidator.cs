using FluentValidation;

namespace Application.Resources.Commands.CreateNewResource;

public class CreateNewResourceValidator : AbstractValidator<CreateNewResourceCmd>
{
    public CreateNewResourceValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Status);
    }
}