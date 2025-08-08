using Application.Common.DTOs.Response.Unit;
using MediatR;

namespace Application.Units.Queries.GetUnitById;

public class GetUnitByIdQry : IRequest<UnitResponse>
{
    public int Id { get; set; }
}