using MasterLoyaltyStore.API.Dtos.Product;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductHandler _productHandler;

    public ProductController(ILogger<ProductController> logger, IProductHandler productHandler)
    {
        _logger = logger;
        _productHandler = productHandler;
    }
    
    #region GET

    [HttpGet]
    [Authorize(Policy = "Admin")]
    [Authorize(Policy = "Customer")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var products = await _productHandler.GetProducts();
            return Ok(products);
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
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created, request);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
    
    
    #endregion

}