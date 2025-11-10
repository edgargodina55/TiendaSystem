using AutoMapper;
using MasterLoyaltyStore.API.Dtos;
using MasterLoyaltyStore.API.Dtos.User;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;
        private readonly IUserHandler _userHandler;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserHandler userHandler, IMapper mapper)
        {
            _logger = logger;
            _userHandler = userHandler;
            _mapper = mapper;
        }
        
        
        #region GET

        [HttpGet]
        [Route("")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var userList = await  _userHandler.GetUsers();
                var users = _mapper.Map<List<UserDto>>(userList);
                var response = ApiResponse<List<UserDto>>.SuccessResponse(users,"OK");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
        
        #endregion
        
        #region POST
        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest createUserRequest)
        {
            try
            {
                var user = _mapper.Map<User>(createUserRequest);
                await _userHandler.CreateUserAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        #endregion
        
        #region PUT
        #endregion
        
        #region DELETE
        #endregion
        
    }


}