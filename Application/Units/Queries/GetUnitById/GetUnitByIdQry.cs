using Domain.Entities;
using MediatR;

namespace Application.Units.Queries.GetUnitById;

public class GetUnitByIdQry : IRequest<UnitOfMeasurement>
{
    public int Id { get; set; }
}