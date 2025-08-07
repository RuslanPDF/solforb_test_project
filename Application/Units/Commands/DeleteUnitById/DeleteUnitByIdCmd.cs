using MediatR;

namespace Application.Units.Commands.DeleteUnitById;

public class DeleteUnitByIdCmd : IRequest
{
    public int Id { get; set; }
}