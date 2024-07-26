using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace GymApi;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        this._userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<BaseReponse>> AsignRole(AsingRoleDto asingRole)
    {
        var serviceResponse = await this._userService.AsignRole(asingRole);

        if(serviceResponse.StatusCode >= 500) return StatusCode(500, serviceResponse);
        
        if( serviceResponse.StatusCode > 299 ) return BadRequest(serviceResponse);

        return Ok(serviceResponse);
    }

}
