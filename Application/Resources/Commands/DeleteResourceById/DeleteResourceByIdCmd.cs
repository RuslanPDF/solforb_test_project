using MediatR;

namespace Application.Resources.Commands.DeleteResourceById;

public class DeleteResourceByIdCmd : IRequest
{
    public int Id { get; set; }
}