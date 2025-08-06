using Application.Common.Persistence;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Resources.Queries.GetResourceAll;

public class GetResourceAll(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetResourceAllQry, List<Resource>>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task<List<Resource>> Handle(GetResourceAllQry request, CancellationToken cancellationToken)
    {
        var resources = await _resourceRepository.GetAllAsync();
        return resources;
    }
}