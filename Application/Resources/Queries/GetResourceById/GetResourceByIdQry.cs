using Domain.Entities;
using MediatR;

namespace Application.Resources.Queries.GetResourceById;

public class GetResourceByIdQry : IRequest<Resource>
{
    public int Id { get; set; }
}