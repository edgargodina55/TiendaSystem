using MasterLoyaltyStore.API.Dtos;
using MasterLoyaltyStore.Bussiness.Interfaces.Exception;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Middleware;

public class GlobalExceptionHandler
{
    private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

    public GlobalExceptionHandler(IEnumerable<IExceptionHandler> exceptionHandlers)
    {
        _exceptionHandlers = exceptionHandlers;
    }


    public IActionResult HandleException(Exception exception)
    {
        var result = _exceptionHandlers
            .Select(handler => handler.HandleException(exception))
            .FirstOrDefault(result => result != null);

        if (result != null)
            return result;
        
        //Status500
        var response = ApiResponse<object>.ErrorResponse(StatusCodes.Status500InternalServerError, exception.Message);
        return new ObjectResult(response);
    }
}