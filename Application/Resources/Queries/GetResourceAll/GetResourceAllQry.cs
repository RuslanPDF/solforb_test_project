using Domain.Entities;
using MediatR;

namespace Application.Resources.Queries.GetResourceAll;

public class GetResourceAllQry : IRequest<List<Resource>>
{
}