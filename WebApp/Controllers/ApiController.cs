using System.Security.Claims;
using Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.DTOs;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    protected ApiController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected static ApiResponse<T> FormatResponse<T>(T data, int status = 200)
    {
        var result = new ApiResponse<T>
        {
            Data = data,
            Status = status
        };

        return result;
    }
    
    protected static ApiResponse FormatResponse(int status = 200)
    {
        var result = new ApiResponse
        {
            Data = null,
            Status = status
        };

        return result;
    }
    
    protected int GetUserId()
    {
        var subClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (subClaim == null)
        {
            throw new BadRequestException("Not valid JWT: name identifier not provide");
        }
        
        var result = int.TryParse(subClaim.Value, out var id);
        if (!result)
        {
            throw new BadRequestException("Not valid JWT: incorrect name identifier format");
        }
    
        return id;
    }  
}