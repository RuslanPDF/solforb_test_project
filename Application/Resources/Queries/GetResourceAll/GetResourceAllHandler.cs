using Application.Common.DTOs.Response.Resource;
using Application.Common.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Resources.Queries.GetResourceAll;

public class GetResourceAll(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetResourceAllQry, List<ResourceResponse>>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task<List<ResourceResponse>> Handle(GetResourceAllQry request, CancellationToken cancellationToken)
    {
        var resources = await _resourceRepository.GetAllAsync(request.Status);
        return _mapper.Map<List<ResourceResponse>>(resources);
    }
}