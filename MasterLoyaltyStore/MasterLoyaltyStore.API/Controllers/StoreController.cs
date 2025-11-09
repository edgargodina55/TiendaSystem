using AutoMapper;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly ILogger<StoreController> _logger;
    private readonly IStoreHandler _storeHandler;
    private readonly IMapper _mapper;

    public StoreController(ILogger<StoreController> logger,IStoreHandler storeHandler)
    {
        _logger = logger;
        _storeHandler = storeHandler;
    }
    
    
    #region GET
    #endregion
    #region POST

    [HttpPost]
    public async Task<IActionResult> CreateStore(Store store)
    {
        try
        {
            
            await _storeHandler.CreateStoreAsync(store);
            
            
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