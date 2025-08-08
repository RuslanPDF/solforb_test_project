using Application.Common.DTOs.Response.Unit;
using MediatR;

namespace Application.Units.Queries.GetUnitAll;

public class GetUnitAllQry : IRequest<List<UnitResponse>>
{
    public string Status { get; set; } = string.Empty;
}