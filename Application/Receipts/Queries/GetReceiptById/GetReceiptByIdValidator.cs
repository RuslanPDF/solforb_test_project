using FluentValidation;

namespace Application.Receipts.Queries.GetReceiptById;

public class GetReceiptByIdValidator : AbstractValidator<GetReceiptByIdQry>
{
    public GetReceiptByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}