using Application.Common.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptById;

public class GetReceiptByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetReceiptByIdQry, ReceiptDocument>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task<ReceiptDocument> Handle(GetReceiptByIdQry request, CancellationToken cancellationToken)
    {
        var receipt = await _receiptRepository.GetByIdAsync(request.Id);
        return receipt;
    }
}