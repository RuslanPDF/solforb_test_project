using Application.Common.Persistence;
using MediatR;

namespace Application.Resources.Commands.DeleteResourceById;

public class DeleteResourceByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteResourceByIdCmd>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task Handle(DeleteResourceByIdCmd request, CancellationToken cancellationToken)
    {
        var resource = await _resourceRepository.GetByIdAsync(request.Id);

        _resourceRepository.Remove(resource);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}