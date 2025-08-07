using MediatR;

namespace WebApp.Controllers;

public class ReceiptController : ApiController
{
    public ReceiptController(IMediator mediator) : base(mediator)
    {
    }
}