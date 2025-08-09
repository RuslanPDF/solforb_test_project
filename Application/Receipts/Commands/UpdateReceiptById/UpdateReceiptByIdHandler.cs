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

        var incomingIds = request.Items
            .Where(i => i.Id != null && i.Id != 0)
            .Select(i => i.Id)
            .ToList();

        var rowsToDelete = receipt.ReceiptResources
            .Where(rr => !incomingIds.Contains(rr.Id))
            .ToList();

        foreach (var row in rowsToDelete)
        {
            receipt.ReceiptResources.Remove(row);
        }

        Console.WriteLine(request.Items.Count);
        
        foreach (var item in request.Items)
        {
            var existing = receipt.ReceiptResources.FirstOrDefault(rr => rr.Id == item.Id);
            if (existing != null && existing.Id != 0)
            {
                existing.Quantity = item.Quantity;
                existing.UnitOfMeasurementId = item.UnitOfMeasurementId;
                existing.ResourceId = item.ResourceId;
            }
            else
            {
                receipt.ReceiptResources.Add(new ReceiptResource
                {
                    ResourceId = item.ResourceId,
                    UnitOfMeasurementId = item.UnitOfMeasurementId,
                    Quantity = item.Quantity,
                    ReceiptDocumentId = receipt.Id,
                });
            }
        }

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}