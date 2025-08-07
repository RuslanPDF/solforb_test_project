using Application.Common.Persistence;
using MediatR;

namespace Application.Units.Commands.DeleteUnitById;

public class DeleteUnitByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteUnitByIdCmd>
{
    private readonly IUnitRepository _unitRepository = _unitOfWork.GetRepository<IUnitRepository>();

    public async Task Handle(DeleteUnitByIdCmd request, CancellationToken cancellationToken)
    {
        var unit = await _unitRepository.GetByIdAsync(request.Id);

        _unitRepository.Remove(unit);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}