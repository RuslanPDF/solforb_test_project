namespace Application.Common.DTOs.Response.Unit;

public class UnitResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}