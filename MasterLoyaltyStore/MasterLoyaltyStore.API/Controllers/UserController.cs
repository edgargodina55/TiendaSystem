using MasterLoyaltyStore.API.Dtos.User;
using MasterLoyaltyStore.Entities.Enums;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        
        
        #region GET
        #endregion
        
        #region POST
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest createUserRequest)
        {
            try
            {
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