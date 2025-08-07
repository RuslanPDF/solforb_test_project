using Application.Common.DTOs.Request.Receipts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ReceiptController : ApiController
{
    public ReceiptController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task GetReceiptById([FromRoute] int id)
    {
    }

    [HttpPost]
    public async Task GetReceiptAll([FromBody] GetReceiptAllRequest body)
    {
    }
}