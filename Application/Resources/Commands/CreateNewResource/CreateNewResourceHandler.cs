using Application.Common.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Resources.Commands.CreateNewResource;

public class CreateNewResourceHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateNewResourceCmd>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task Handle(CreateNewResourceCmd request, CancellationToken cancellationToken)
    {
        await _resourceRepository.CheckNameExists(request.Name);

        var resource = new Resource
        {
            Name = request.Name,
            Status = request.Status,
        };

        await _resourceRepository.Insert(resource);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}