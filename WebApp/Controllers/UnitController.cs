using Application.Common.DTOs.Request.Units;
using Application.Units.Commands.CreateNewUnit;
using Application.Units.Commands.DeleteUnitById;
using Application.Units.Commands.UpdateUnitById;
using Application.Units.Queries.GetUnitAll;
using Application.Units.Queries.GetUnitById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.DTOs;

namespace WebApp.Controllers;

public class UnitController : ApiController
{
    public UnitController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ApiResponse<List<UnitOfMeasurement>>> GetUnitAll()
    {
        var query = new GetUnitAllQry();
        var result = await Mediator.Send(query);
        return FormatResponse(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<UnitOfMeasurement>> GetUnitById([FromRoute] int id)
    {
        var query = new GetUnitByIdQry
        {
            Id = id
        };
        var result = await Mediator.Send(query);
        return FormatResponse(result);
    }

    [HttpDelete("{id}")]
    public async Task DeleteUnitById([FromRoute] int id)
    {
        var cmd = new DeleteUnitByIdCmd
        {
            Id = id
        };
        await Mediator.Send(cmd);
    }

    [HttpPut("{id}")]
    public async Task UpdateUnitById([FromRoute] int id, [FromBody] UpdateUnitByIdRequest unit)
    {
        var cmd = new UpdateUnitByIdCmd
        {
            Name = unit.Name,
            Status = unit.Status,
            Id = id
        };
        await Mediator.Send(cmd);
    }

    [HttpPost]
    public async Task CreateNewUnit([FromBody] CreateNewUnitRequest unit)
    {
        var cmd = new CreateNewUnitCmd
        {
            Name = unit.Name,
            Status = unit.Status,
        };
        await Mediator.Send(cmd);
    }
}