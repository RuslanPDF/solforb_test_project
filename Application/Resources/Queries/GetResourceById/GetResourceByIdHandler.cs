using Application.Common.DTOs.Response.Resource;
using Application.Common.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Resources.Queries.GetResourceById;

public class GetResourceById(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetResourceByIdQry, ResourceResponse>
{
    private readonly IResourceRepository _resourceRepository = _unitOfWork.GetRepository<IResourceRepository>();

    public async Task<ResourceResponse> Handle(GetResourceByIdQry request, CancellationToken cancellationToken)
    {
        var resource = await _resourceRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ResourceResponse>(resource);
    }
}