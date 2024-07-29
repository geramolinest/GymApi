using Microsoft.AspNetCore.Mvc;

namespace GymApi;

[ApiController]
[Route("api/v1/suscriptions")]
public class SuscriptionsController : ControllerBase
{
    private readonly SuscriptionsService _suscriptionsService;

    public SuscriptionsController(SuscriptionsService suscriptionsService)
    {
        this._suscriptionsService = suscriptionsService;
    }

    [HttpPost("add-suscription")]
    public async Task<ActionResult<BaseReponse>> AddSuscriptionToSuscriptor(SuscriptionAddDto suscriptionAdd)
    {
        var serviceResult = await this._suscriptionsService.AddSuscription(suscriptionAdd);

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);

        if(serviceResult.StatusCode > 299) return BadRequest(serviceResult);

        return Ok(serviceResult);
    }

    [HttpPost("renew-suscription")]
    public async Task<ActionResult<BaseReponse>> RenewSuscription(RenewSuscriptionDto renewSuscription)
    {
        var serviceResult = await this._suscriptionsService.RenewSubscription(renewSuscription);

        if(serviceResult.StatusCode >= 500) return StatusCode(500, serviceResult);

        if(serviceResult.StatusCode > 299) return BadRequest(serviceResult);

        return Ok(serviceResult);
    }
}
