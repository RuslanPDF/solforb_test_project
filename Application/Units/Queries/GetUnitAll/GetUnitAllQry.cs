using Domain.Entities;
using MediatR;

namespace Application.Units.Queries.GetUnitAll;

public class GetUnitAllQry : IRequest<List<UnitOfMeasurement>>
{
}