using Application.Common.Persistence;
using MediatR;

namespace Application.Resources.Commands.DeleteResourceById;

public class DeleteResourceByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteResourceByIdCmd>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task Handle(DeleteResourceByIdCmd request, CancellationToken cancellationToken)
    {
        _resourceRepository.RemoveById(request.Id);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}