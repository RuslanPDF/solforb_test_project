using Application.Common.DTOs.Request.Resources;
using Application.Resources.Commands.CreateNewResource;
using Application.Resources.Commands.DeleteResourceById;
using Application.Resources.Commands.UpdateResourceById;
using Application.Resources.Queries.GetResourceAll;
using Application.Resources.Queries.GetResourceById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.DTOs;

namespace WebApp.Controllers;

public class ResourceController : ApiController
{
    public ResourceController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ApiResponse<List<Resource>>> GetResourceAll()
    {
        var query = new GetResourceAllQry();
        var results = await Mediator.Send(query);
        return FormatResponse(results);
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<Resource>> GetResourceById([FromRoute] int id)
    {
        var query = new GetResourceByIdQry { Id = id };
        var results = await Mediator.Send(query);
        return FormatResponse(results);
    }

    [HttpDelete("{id}")]
    public async Task DeleteResourceById([FromRoute] int id)
    {
        var cmd = new DeleteResourceByIdCmd
        {
            Id = id,
        };

        await Mediator.Send(cmd);
    }

    [HttpPut("{id}")]
    public async Task UpdateResourceById([FromRoute] int id, [FromBody] UpdateResourceByIdRequest body)
    {
        var cmd = new UpdateResourceByIdCmd
        {
            Id = id,
            Name = body.Name,
            Status = body.Status,
        };

        await Mediator.Send(cmd);
    }

    [HttpPost]
    public async Task CreateNewResource([FromBody] CreateNewResourceRequest body)
    {
        var cmd = new CreateNewResourceCmd
        {
            Name = body.Name,
            Status = body.Status
        };

        await Mediator.Send(cmd);
    }
}