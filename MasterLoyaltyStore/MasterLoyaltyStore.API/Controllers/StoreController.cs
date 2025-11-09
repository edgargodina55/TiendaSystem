using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly ILogger<StoreController> _logger;
    private readonly IStoreRepository _storeRepository;

    public StoreController(ILogger<StoreController> logger, IStoreRepository storeRepository)
    {
        _logger = logger;
        _storeRepository = storeRepository;
    }
    
    
    #region GET
    #endregion
    #region POST

    [HttpPost]
    public async Task<IActionResult> CreateStore(Store store)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created,new
            {
                success = true,
                message = "Store created successfully!"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
        }
    }
    #endregion
    
    
    
}