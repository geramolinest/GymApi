using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymApi;

[ApiController]
[Route("api/v1/roles")]
[Authorize(Roles = "ADMIN")]
public class RolesController : ControllerBase 
{
    private readonly RoleService _roleService;

    public RolesController(RoleService roleService)
    {
        this._roleService = roleService;
    }
    

    [HttpPost]
    public async Task<ActionResult<BaseReponse>> AddRole(AddRoleDto addRoleDto)
    {
        var serviceResponse = await this._roleService.AddRole(addRoleDto);

        if(serviceResponse.StatusCode >= 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode>299) return BadRequest(serviceResponse);

        return Ok(serviceResponse);
    }

    [HttpGet(Name = "Get All Roles")]
    public async Task<ActionResult<BaseReponse>> GetAllRoles()
    {
        var serviceResponse = await this._roleService.GetRoles();

        if(serviceResponse.StatusCode >= 500) return StatusCode(500, serviceResponse);

        return Ok(serviceResponse);
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<BaseReponse>> GetRoleByName(string name)
    {
        var serviceResponse = await this._roleService.GetRole(name.ToUpper());

        if(serviceResponse.StatusCode >= 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299) return NotFound(serviceResponse);

        return Ok(serviceResponse);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<BaseReponse>> GetRoleById(string id)
    {
        var serviceResponse = await this._roleService.GetRoleById(id);

        if(serviceResponse.StatusCode >= 500) return StatusCode(500, serviceResponse);

        if(serviceResponse.StatusCode > 299) return NotFound(serviceResponse);

        return Ok(serviceResponse);
    }
}
