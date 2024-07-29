using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace GymApi;

[ApiController]
[Route("api/v1/checkin")]
public class CheckInController : ControllerBase
{
    private readonly CheckInService _checkInService;

    public CheckInController(CheckInService checkInService)
    {
        this._checkInService = checkInService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BaseReponse>> CheckIn(int id)
    {
        var serviceResponse = await this._checkInService.CheckIn(id);

        if(serviceResponse.StatusCode >=500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299 ) return BadRequest(serviceResponse);

        return Ok(serviceResponse);
    }
}
