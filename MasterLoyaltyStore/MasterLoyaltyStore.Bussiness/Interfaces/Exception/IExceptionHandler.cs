using Microsoft.AspNetCore.Mvc;
namespace MasterLoyaltyStore.Bussiness.Interfaces.Exception;

public interface IExceptionHandler
{
    IActionResult HandleException(System.Exception ex);
}