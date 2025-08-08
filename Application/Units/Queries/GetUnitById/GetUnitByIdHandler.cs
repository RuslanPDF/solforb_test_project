using Application.Common.DTOs.Response.Unit;
using Application.Common.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Units.Queries.GetUnitById;

public class GetUnitById(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetUnitByIdQry, UnitResponse>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task<UnitResponse> Handle(GetUnitByIdQry request, CancellationToken cancellationToken)
    {
        var unit = await _unitRepository.GetByIdAsync(request.Id);
        return _mapper.Map<UnitResponse>(unit);
    }
}