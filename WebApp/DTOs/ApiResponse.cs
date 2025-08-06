namespace WebApp.DTOs;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string[] Errors { get; set; } = Array.Empty<string>();
    public int Status { get; set; }
}

public class ApiResponse
{
    public object? Data { get; set; } = null;
    public string[] Errors { get; set; } = Array.Empty<string>();
    public int Status { get; set; }
}