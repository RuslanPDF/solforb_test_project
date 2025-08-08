using Application.Common.DTOs.Filter;
using Application.Common.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptAll;

public class GetReceiptAllHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetReceiptAllQry, List<ReceiptDocument>>
{
    private readonly IReceiptRepository _receiptRepository = _unitOfWork.GetRepository<IReceiptRepository>();

    public async Task<List<ReceiptDocument>> Handle(GetReceiptAllQry request, CancellationToken cancellationToken)
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
        return receipt;
    }
}