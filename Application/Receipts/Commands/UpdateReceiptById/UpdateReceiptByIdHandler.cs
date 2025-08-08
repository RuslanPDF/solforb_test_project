using Application.Common.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Receipts.Commands.UpdateReceiptById;

public class UpdateReceiptByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateReceiptByIdCmd>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task Handle(UpdateReceiptByIdCmd request, CancellationToken cancellationToken)
    {
        var receipt = await _receiptRepository.GetByIdAsync(request.Id);

        receipt.Number = request.Number;
        receipt.Date = request.Date;

        foreach (var item in request.Items)
        {
            var existing = receipt.ReceiptResources.FirstOrDefault(rr => rr.Id == item.Id);
            if (existing != null)
            {
                existing.Quantity = item.Quantity;
                existing.UnitOfMeasurementId = item.UnitId;
                existing.ResourceId = item.ResourceId;
            }
            else
            {
                receipt.ReceiptResources.Add(new ReceiptResource
                {
                    ResourceId = item.ResourceId,
                    UnitOfMeasurementId = item.UnitId,
                    Quantity = item.Quantity,
                    ReceiptDocumentId = receipt.Id,
                });
            }
        }
    }
}