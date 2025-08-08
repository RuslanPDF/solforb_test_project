using MediatR;

namespace Application.Receipts.Commands.DeleteReceiptById;

public class DeleteReceiptByIdCmd : IRequest
{
    public int Id { get; set; }
}