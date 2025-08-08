using Application.Common.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Receipts.Commands.CreateNewReceipt;

public class CreateNewReceiptHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateNewReceiptCmd>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task Handle(CreateNewReceiptCmd request, CancellationToken cancellationToken)
    {
        var receipt = new ReceiptDocument
        {
            Number = request.Number,
            Date = request.Date,
            ReceiptResources = request.Items.Select(item => new ReceiptResource
            {
                ResourceId = item.ResourceId,
                UnitOfMeasurementId = item.UnitOfMeasurementId,
                Quantity = item.Quantity,
            }).ToList()
        };

        await _receiptRepository.Insert(receipt);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}