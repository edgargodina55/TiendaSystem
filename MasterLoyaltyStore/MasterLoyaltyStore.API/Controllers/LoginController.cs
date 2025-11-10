using AutoMapper;
using MasterLoyaltyStore.API.Dtos;
using MasterLoyaltyStore.API.Dtos.Login;
using MasterLoyaltyStore.API.Dtos.User;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class LoginController : ControllerBase
{
    
    private readonly ILogger<LoginController> _logger;
    private readonly ILoginHandler _loginHandler;
    private readonly IMapper _mapper;
    
    public LoginController(ILogger<LoginController> logger, ILoginHandler loginHandler, IMapper mapper)
    {
        _loginHandler = loginHandler;
        _logger = logger;
        _mapper = mapper;
    }
    
    
    
    #region POST

    [HttpPost]
    [Route("Authenticate")]
    public async Task<IActionResult> Login(LoginRequest user)
    {
        if (!ModelState.IsValid)
        {
            var response =
                ApiResponse<Object>.ErrorResponse(StatusCodes.Status400BadRequest, "Solicitud invalidad");
            return BadRequest(response);
        }
        try
        {
            var loginResponse = await _loginHandler.Authenticate(user.Email, user.Password);
            var userdTO = _mapper.Map<UserDto>(loginResponse.User);
            var response = ApiResponse<object>.SuccessResponse(new 
            {
                User = userdTO,
                Token = loginResponse.Token,
            }, "Login exitoso");
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
    
    
    #endregion
}