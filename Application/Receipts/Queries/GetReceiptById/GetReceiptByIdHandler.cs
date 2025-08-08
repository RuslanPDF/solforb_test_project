using Application.Common.DTOs.Response;
using Application.Common.DTOs.Response.Receipt;
using Application.Common.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptById;

public class GetReceiptByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetReceiptByIdQry, ReceiptDocumentResponse>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task<ReceiptDocumentResponse> Handle(GetReceiptByIdQry request, CancellationToken cancellationToken)
    {
        var receipt = await _receiptRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ReceiptDocumentResponse>(receipt);
    }
}