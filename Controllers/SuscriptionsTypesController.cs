using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace GymApi;

[ApiController]
[Route("api/v1/suscriptionstypes")]
public class SuscriptionsTypesController : ControllerBase
{
    private readonly SuscriptionsTypesService _suscriptionsTypesService;

    public SuscriptionsTypesController(SuscriptionsTypesService suscriptionsTypesService)
    {
        this._suscriptionsTypesService = suscriptionsTypesService;
    }

    [HttpPost]
    public async Task<ActionResult<BaseReponse>> AddSuscriptionType(AddSuscriptionTypeDto addSuscriptionType)
    {
        var serviceResult = await this._suscriptionsTypesService.AddSuscriptionType(addSuscriptionType);

        if(serviceResult.StatusCode>=500) return StatusCode(500, serviceResult.Data);

        if(serviceResult.StatusCode>299) return BadRequest(serviceResult);

        return Ok(serviceResult);
    }

    [HttpGet]
    public async Task<ActionResult<BaseReponse>> GetAllSuscriptionsTypes()
    {
        var serviceResult = await this._suscriptionsTypesService.GetSuscriptionsTypes();

        if(serviceResult.StatusCode>=500) return StatusCode(500, serviceResult.Data);

        return Ok(serviceResult);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BaseReponse>> GetSuscriptionType(int id) 
    {
        var serviceResponse = await this._suscriptionsTypesService.GetSuscriptionType(id);

        if(serviceResponse.StatusCode>=500) return StatusCode(500, serviceResponse.Data);

        if(serviceResponse.StatusCode == 404) return NotFound(serviceResponse);

        if(serviceResponse.StatusCode>299) return BadRequest(serviceResponse);

        return Ok(serviceResponse);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<BaseReponse>> UpdateSuscriptionType(int id, UpdateSuscriptionTypeDto updateSuscriptionType)
    {
        var serviceResponse = await this._suscriptionsTypesService.UpdateSuscriptionType(id, updateSuscriptionType);

        if(serviceResponse.StatusCode>=500) return StatusCode(500, serviceResponse.Data);
        if(serviceResponse.StatusCode>299) return BadRequest(serviceResponse);

        return Ok(serviceResponse);
    }
}
