using Microsoft.AspNetCore.Mvc;

namespace GymApi;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        this._productsService = productsService;
    }

    [HttpPost]
    public async Task<ActionResult<BaseReponse>> AddProduct(AddProductDto addProduct)
    {
        var serviceResponse = await this._productsService.AddProduct(addProduct);

        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode >299) return BadRequest(serviceResponse);

        return Ok(serviceResponse);
    }

    [HttpGet]
    public async Task<ActionResult<BaseReponse>> GetAllProducts()
    {
        var serviceResponse = await this._productsService.GetAllProducts();
        
        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);
        
        return Ok(serviceResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BaseReponse>> GetProductById(int id)
    {
        var serviceResponse = await this._productsService.GetProductById(id);
        
        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode == 404) return NotFound(serviceResponse);
        
        return Ok(serviceResponse);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BaseReponse>> UpdateProduct(int id, UpdateProductDto updateProduct)
    {
        var serviceResponse = await this._productsService.UpdateProduct(id, updateProduct);
        
        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299) return BadRequest(serviceResponse);
        
        return Ok(serviceResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<BaseReponse>> DeleProduct(int id)
    {
        var serviceResponse = await this._productsService.DeleteProduct(id);
        
        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299) return BadRequest(serviceResponse);
        
        return Ok(serviceResponse);
    }
}
