using Application.Common.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Units.Queries.GetUnitAll;

public class GetUnitAll(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetUnitAllQry, List<UnitOfMeasurement>>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task<List<UnitOfMeasurement>> Handle(GetUnitAllQry request, CancellationToken cancellationToken)
    {
        var units = await _unitRepository.GetAllAsync();
        return units;
    }
}