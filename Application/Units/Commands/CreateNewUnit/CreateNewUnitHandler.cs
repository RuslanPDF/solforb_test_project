using Application.Common.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Units.Commands.CreateNewUnit;

public class CreateNewUnitHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateNewUnitCmd>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task Handle(CreateNewUnitCmd request, CancellationToken cancellationToken)
    {
        await _unitRepository.CheckNameExists(request.Name);

        var unit = new UnitOfMeasurement
        {
            Name = request.Name,
            Status = request.Status,
        };

        await _unitRepository.Insert(unit);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}