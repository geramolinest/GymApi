using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApi;

[ApiController]
[Route("api/v1/sales")]
public class SalesController : ControllerBase
{
    private readonly SalesService _salesService;

    public SalesController(SalesService salesService)
    {
        this._salesService = salesService;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddSale(CreateSaleDto addSale)
    {
       
        
        var serviceResponse = await this._salesService.CreateSale(addSale);

        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299) return BadRequest(serviceResponse);

        return StatusCode(201, serviceResponse);
       
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetSalesBySuscriptor(int id)
    {
        var serviceResponse = await this._salesService.GetOrdersBySucriptor(id);

        if(serviceResponse.StatusCode == 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299) return NotFound(serviceResponse);

        return Ok(serviceResponse);
    }
}
