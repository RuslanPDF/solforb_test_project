namespace Application.Common.DTOs.Request.Units;

public class UpdateUnitByIdRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}