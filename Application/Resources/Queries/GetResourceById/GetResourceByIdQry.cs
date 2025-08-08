using Application.Common.DTOs.Response.Resource;
using MediatR;

namespace Application.Resources.Queries.GetResourceById;

public class GetResourceByIdQry : IRequest<ResourceResponse>
{
    public int Id { get; set; }
}