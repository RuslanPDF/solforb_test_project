using MediatR;

namespace Application.Resources.Commands.CreateNewResource;

public class CreateNewResourceCmd : IRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    
}