using MediatR;

namespace Application.Resources.Commands.UpdateResourceById;

public class UpdateResourceByIdCmd : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}