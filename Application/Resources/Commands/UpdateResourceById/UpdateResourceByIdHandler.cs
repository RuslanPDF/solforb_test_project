using Application.Common.Persistence;
using MediatR;

namespace Application.Resources.Commands.UpdateResourceById;

public class UpdateResourceByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateResourceByIdCmd>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task Handle(UpdateResourceByIdCmd request, CancellationToken cancellationToken)
    {
        var resource = await _resourceRepository.GetByIdAsync(request.Id);

        resource.Name = request.Name;
        resource.Status = request.Status;

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}