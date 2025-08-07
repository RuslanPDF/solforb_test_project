using MediatR;

namespace Application.Units.Commands.UpdateUnitById;

public class UpdateUnitByIdCmd : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}