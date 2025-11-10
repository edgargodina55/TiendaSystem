using AutoMapper;
using MasterLoyaltyStore.API.Dtos.Product;
using MasterLoyaltyStore.Bussiness.Handlers.Interfaces;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterLoyaltyStore.API.Controllers;

[Route("api/products")]
[AllowAnonymous]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductHandler _productHandler;
    private readonly IMapper _mapper;

    public ProductController(ILogger<ProductController> logger, IProductHandler productHandler,IMapper mapper)
    {
        _logger = logger;
        _productHandler = productHandler;
        _mapper = mapper;
    }
    
    #region GET

    [HttpGet]
    [Authorize(Roles = "Admin")]
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
    
    [HttpGet]
    [Authorize(Roles = "Customer,Admin")]
    [Route("{storeId:int}")]
    public async Task<IActionResult> GetProductsByStoreId([FromRoute]int storeId)
    {
        try
        {
            var products = await _productHandler.GetProductsByStoreId(storeId);
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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest request)
    {
        try
        {
            var newProduct = _mapper.Map<Product>(request);
            var response = await _productHandler.CreateAsync(newProduct);
            return StatusCode(StatusCodes.Status201Created, request);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
    
    
    #endregion

}