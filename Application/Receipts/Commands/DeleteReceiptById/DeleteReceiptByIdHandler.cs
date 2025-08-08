using Application.Common.Persistence;
using MediatR;

namespace Application.Receipts.Commands.DeleteReceiptById;

public class DeleteReceiptByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteReceiptByIdCmd>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task Handle(DeleteReceiptByIdCmd request, CancellationToken cancellationToken)
    {
        _receiptRepository.RemoveById(request.Id);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}