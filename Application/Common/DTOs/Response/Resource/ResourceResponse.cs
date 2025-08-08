namespace Application.Common.DTOs.Response.Resource;

public class ResourceResponse : BaseResponse
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
}