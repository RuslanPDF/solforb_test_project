using Application.Common.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Resources.Queries.GetResourceById;

public class GetResourceById(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetResourceByIdQry, Resource>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task<Resource> Handle(GetResourceByIdQry request, CancellationToken cancellationToken)
    {
        var resource = await _resourceRepository.GetByIdAsync(request.Id);
        return resource;
    }
}