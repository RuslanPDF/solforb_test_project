using Application.Common.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Units.Queries.GetUnitById;

public class GetUnitById(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetUnitByIdQry, UnitOfMeasurement>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task<UnitOfMeasurement> Handle(GetUnitByIdQry request, CancellationToken cancellationToken)
    {
        var unit = await _unitRepository.GetByIdAsync(request.Id);
        return unit;
    }
}