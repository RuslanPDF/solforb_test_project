using Application.Common.DTOs.Request.Resources;
using FluentValidation;

namespace Application.Receipts.Commands.UpdateReceiptById;

public class UpdateReceiptByIdValidator : AbstractValidator<UpdateReceiptByIdCmd>
{
    public UpdateReceiptByIdValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty();

        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.Items.Select(i => i.ResourceId))
            .Must(ids => ids.Distinct().Count() == ids.Count())
            .WithMessage("Dublicate Resources Not Unique");

        RuleForEach(x => x.Items)
            .SetValidator(new ResourceItemRequestValidator());
    }
}

public class ResourceItemRequestValidator : AbstractValidator<ResourceItemRequest>
{
    public ResourceItemRequestValidator()
    {
        RuleFor(x => x.ResourceId).GreaterThan(0);
        RuleFor(x => x.UnitId).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}