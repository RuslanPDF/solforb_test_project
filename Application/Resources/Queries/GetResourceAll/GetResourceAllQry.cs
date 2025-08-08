using Application.Common.DTOs.Response.Resource;
using MediatR;

namespace Application.Resources.Queries.GetResourceAll;

public class GetResourceAllQry : IRequest<List<ResourceResponse>>
{
    public string Status { get; set; } = string.Empty;
}