using FluentValidation;

namespace Application.Receipts.Commands.DeleteReceiptById;

public class DeleteReceiptByIdValidator : AbstractValidator<DeleteReceiptByIdCmd>
{
    public DeleteReceiptByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}