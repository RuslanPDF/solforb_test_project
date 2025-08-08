using Application.Common.DTOs.Response.Unit;
using Application.Common.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Units.Queries.GetUnitAll;

public class GetUnitAll(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetUnitAllQry, List<UnitResponse>>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task<List<UnitResponse>> Handle(GetUnitAllQry request, CancellationToken cancellationToken)
    {
        var units = await _unitRepository.GetAllAsync(request.Status);
        return _mapper.Map<List<UnitResponse>>(units);
    }
}