using Application.Common.Persistence;
using MediatR;

namespace Application.Units.Commands.UpdateUnitById;

public class UpdateUnitByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateUnitByIdCmd>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task Handle(UpdateUnitByIdCmd request, CancellationToken cancellationToken)
    {
        var unit = await _unitRepository.GetByIdAsync(request.Id);

        unit.Name = request.Name;
        unit.Status = request.Status;

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}