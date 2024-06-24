using Common.ResultPattern;

using Microsoft.AspNetCore.Mvc;

namespace ResultPattern.WebApi.Controllers;

/// <summary>
/// Represents a base controller for the Web API.
/// </summary>
[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Returns a problem response with the specified error details.
    /// </summary>
    /// <param name="error">The error details.</param>
    /// <returns>A problem response with the specified error details.</returns>
    protected IActionResult Problem(Error error)
    {
        var statusCode = error.ErrorType switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.AccessUnAuthorized => StatusCodes.Status401Unauthorized,
            ErrorType.AccessForbidden => StatusCodes.Status403Forbidden,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            title: error.Description,
            detail: error.Code);
    }
}

