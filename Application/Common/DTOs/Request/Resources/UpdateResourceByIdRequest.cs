namespace Application.Common.DTOs.Request.Resources;

public class UpdateResourceByIdRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}