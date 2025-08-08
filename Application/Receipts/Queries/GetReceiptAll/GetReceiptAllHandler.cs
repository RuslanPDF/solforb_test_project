using Application.Common.DTOs.Filter;
using Application.Common.DTOs.Response;
using Application.Common.DTOs.Response.Receipt;
using Application.Common.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptAll;

public class GetReceiptAllHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetReceiptAllQry, List<ReceiptDocumentResponse>>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task<List<ReceiptDocumentResponse>> Handle(GetReceiptAllQry request, CancellationToken cancellationToken)
    {
        var filter = new ReceiptFilter
        {
            DateFrom = request.DateFrom,
            DateTo = request.DateTo,
            Numbers = request.Numbers,
            ResourceIds = request.ResourceIds,
            UnitIds = request.UnitIds
        };
        var receipt = await _receiptRepository.GetAllAsync(filter);
        return _mapper.Map<List<ReceiptDocumentResponse>>(receipt);
    }
}