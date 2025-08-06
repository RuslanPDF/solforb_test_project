using Application.Common.Exceptions;
using FluentValidation;
using WebApp.DTOs;

namespace WebApp.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var messages = new List<string>();

            switch (ex)
            {
                case EntityExistsException:
                    context.Response.StatusCode = 400;
                    messages.Add(ex.Message);
                    break;
                case EntityNotFoundException:
                    context.Response.StatusCode = 404;
                    messages.Add(ex.Message);
                    break;
                case ValidationException validationException:
                    context.Response.StatusCode = 400;
                    messages = validationException.Errors.Select(x => x.ErrorMessage).ToList();
                    break;
                default:
                    context.Response.StatusCode = 500;
                    messages.Add(ex.Message);
                    
                    _logger.LogError(ex, ex.Message);
                    
                    break;
            }
            
            var response = FormatResponse(messages.ToArray(), context.Response.StatusCode);
            await context.Response.WriteAsJsonAsync(response);
        }
    }

    private static ApiResponse FormatResponse(string[] errors, int status)
    {
        return new ApiResponse
        {
            Errors = errors,
            Status = status
        };
    }
}
