using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymApi;

[ApiController]
[Route("api/v1/suscriptors")]
//[Authorize(Roles = "admin,cashier")]
public class SuscriptorsController : ControllerBase
{
    private readonly SuscriptorsService _service;

    public SuscriptorsController(SuscriptorsService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<ActionResult<BaseReponse>> AddSuscriptor(AddSuscriptorDto suscriptorDto)
    {
        var serviceResult = await this._service.AddSuscriptor(suscriptorDto);

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);

        return Ok(serviceResult);
    }

    [HttpPost("suscribe")]
    public async Task<ActionResult<BaseReponse>> AddSuscriptorSuscription(SuscribeSuscriptorDto suscribe)
    {
        var serviceResult = await this._service.AddSucriptorWithSubscription(suscribe);
        return Ok(serviceResult);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BaseReponse>> GetSuscriptorById(int id)
    {
        var serviceResult = await this._service.GetSuscriptorById(id);

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);

        if(serviceResult.StatusCode >= 300) return NotFound(serviceResult);

        return Ok(serviceResult);
    }
    
    [HttpGet]
    public async Task<ActionResult<BaseReponse>> GetAllSuscriptors()
    {
        var serviceResult = await this._service.GetAllSuscriptors();

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);
        
        return Ok(serviceResult); 
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BaseReponse>>   UpdateSuscriptor(int id, UpdateSuscriptorDto updateSuscriptorDto)
    {
        var serviceResult = await this._service.UpdateSuscriptor(id, updateSuscriptorDto);

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);

        if(serviceResult.StatusCode >= 300) return BadRequest(serviceResult);

        return Ok(serviceResult);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<BaseReponse>> DeleteSuscriptor(int id)
    {
        var serviceResult = await this._service.DeleteSuscriptor(id);

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);

        if(serviceResult.StatusCode >= 300) return BadRequest(serviceResult);

        return Ok(serviceResult);
    }
    
}
