using AutoMapper;
using MasterLoyaltyStore.API.Dtos;
using MasterLoyaltyStore.API.Dtos.Store;
using MasterLoyaltyStore.Data.Repositories.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[ApiController]
[Route("api/stores")]
public class StoreController : ControllerBase
{
    private readonly ILogger<StoreController> _logger;
    private readonly IStoreHandler _storeHandler;
    private readonly IMapper _mapper;

    public StoreController(ILogger<StoreController> logger,IStoreHandler storeHandler,IMapper mapper)
    {
        _logger = logger;
        _storeHandler = storeHandler;
        _mapper = mapper;
    }
    
    
    #region GET
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetStores()
    {
        try
        {
            var storeList = await _storeHandler.GetStores();
            var stores = _mapper.Map<List<StoreDto>>(storeList);
            var response = ApiResponse<List<StoreDto>>.SuccessResponse(stores,"OK");
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
    public async Task<IActionResult> CreateStore(CreateStoreRequest request)
    {
        try
        {
            var store = _mapper.Map<Store>(request);
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