using MediatR;

namespace Application.Units.Commands.CreateNewUnit;

public class CreateNewUnitCmd : IRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}