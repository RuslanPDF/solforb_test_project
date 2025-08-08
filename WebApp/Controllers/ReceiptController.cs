using Application.Common.DTOs.Request.Receipts;
using Application.Common.DTOs.Response;
using Application.Common.DTOs.Response.Receipt;
using Application.Receipts.Commands.CreateNewReceipt;
using Application.Receipts.Commands.DeleteReceiptById;
using Application.Receipts.Commands.UpdateReceiptById;
using Application.Receipts.Queries.GetReceiptAll;
using Application.Receipts.Queries.GetReceiptById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.DTOs;

namespace WebApp.Controllers;

public class ReceiptController : ApiController
{
    public ReceiptController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<ReceiptDocumentResponse>> GetReceiptById([FromRoute] int id)
    {
        var query = new GetReceiptByIdQry
        {
            Id = id
        };
        var result = await Mediator.Send(query);
        return FormatResponse(result);
    }

    [HttpGet]
    public async Task<ApiResponse<List<ReceiptDocumentResponse>>> GetReceiptAll([FromQuery] GetReceiptAllRequest body)
    {
        var query = new GetReceiptAllQry
        {
            DateFrom = body.DateFrom,
            DateTo = body.DateTo,
            Numbers = body.Numbers,
            ResourceIds = body.ResourceIds,
            UnitIds = body.UnitIds
        };
        var result = await Mediator.Send(query);
        return FormatResponse(result);
    }

    [HttpPost]
    public async Task CreateNewReceipt([FromBody] CreateNewReceiptRequest body)
    {
        var cmd = new CreateNewReceiptCmd
        {
            Number = body.Number,
            Date = body.Date,
            Items = body.Items,
        };
        await Mediator.Send(cmd);
    }

    [HttpDelete("{id}")]
    public async Task DeleteReceiptById([FromRoute] int id)
    {
        var cmd = new DeleteReceiptByIdCmd
        {
            Id = id
        };
        await Mediator.Send(cmd);
    }

    [HttpPut("{id}")]
    public async Task UpdateReceiptById([FromRoute] int id, [FromBody] UpdateReceiptByIdRequest body)
    {
        var cmd = new UpdateReceiptByIdCmd
        {
            Id = id,
            Items = body.Items,
            Number = body.Number,
            Date = body.Date,
        };
        await Mediator.Send(cmd);
    }
}