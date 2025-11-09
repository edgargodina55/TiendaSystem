using MasterLoyaltyStore.API.Dtos.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class LoginController : ControllerBase
{
    
    private readonly ILogger<LoginController> _logger;
    
    
    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }
    
    
    
    #region POST

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
    
    
    #endregion
}