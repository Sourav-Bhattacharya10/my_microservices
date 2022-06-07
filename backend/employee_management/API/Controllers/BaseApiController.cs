using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

using employee_management.Application.Responses;
using employee_management.Application.Enums;

namespace employee_management.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private  IMediator _mediator = default!;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

    protected ActionResult HandleResult<T>(ResultResponse<T> result)
    {
        if(result.IsSuccess && result.Value != null)
            return Ok(result);
        else if(!result.IsSuccess && result.ErrorType == ErrorType.NotFound)
            return NotFound(result);
        else if(!result.IsSuccess && result.ErrorType == ErrorType.Validation)
            return BadRequest(result);
        else
            return StatusCode(500, result.ExceptionObject);
    }
}