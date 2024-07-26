using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace GymApi;

public class RoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly GenericsResponse _response;
    private readonly ILogger<RoleService> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, GenericsResponse response, ILogger<RoleService> logger)
    {
        this._roleManager = roleManager;
        this._response = response;
        this._logger = logger;
        this._userManager = userManager;
    }

    public async Task<BaseReponse> AddRole(AddRoleDto addRole)
    {

        try
        {
            var existsRole = await this._roleManager.RoleExistsAsync(addRole.RoleName);

            if (existsRole) return this._response.BadRequestResponse("Role already exists");

            var addResult = await this._roleManager.CreateAsync(new IdentityRole { Name = addRole.RoleName.ToUpper() });

            if (!addResult.Succeeded) return this._response.BadRequestResponse($"Error trying to create new role {addRole.RoleName}", addResult.Errors);

            return this._response.OkResponse($"Role {addRole.RoleName} created successfully");
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> UpdateRole(UpdateRoleDto updateRole)
    {

        try
        {
            var exists = await this._roleManager.RoleExistsAsync(updateRole.OldRole);

            if (!exists) return this._response.BadRequestResponse("Role can not be updated because it does not exists");

            var role = await this._roleManager.FindByNameAsync(updateRole.OldRole);

            role.Name = updateRole.NewRoleName;

            var updatedResult = await this._roleManager.UpdateAsync(role);

            if (!updatedResult.Succeeded) return this._response.BadRequestResponse("We couldn't update the role", updatedResult.Errors);

            return this._response.OkResponse("Role updated successfully");
        }
        catch (Exception ex)
        {
            this._logger.LogCritical(ex.Message, ex);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> DeleteRole(DeleteRoleDto deleteRole)
    {


        try
        {

            var exists = await this._roleManager.RoleExistsAsync(deleteRole.RoleName);

            if (!exists) return this._response.BadRequestResponse("Role can not be deleted because it does not exists");

            var usersRole = await this._userManager.GetUsersInRoleAsync(deleteRole.RoleName);

            if (usersRole.Count > 0) return this._response.BadRequestResponse("Role is asigned, it can not be deleted.");
            var role = await this._roleManager.FindByNameAsync(deleteRole.RoleName);

            var deletedResul = await this._roleManager.DeleteAsync(role);

            if (!deletedResul.Succeeded) return this._response.BadRequestResponse("We could'nt delete the role.", deletedResul.Errors);


            return this._response.OkResponse("Role has been deleted.");
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetRole(String roleName)
    {
        try
        {
            var role = await this._roleManager.FindByNameAsync(roleName);

            if (role == null) return this._response.NotFoundResponse("Role does not exists");

            return this._response.OkResponse("", role);
        }
        catch (Exception e)
        {

            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetRoleById(String id)
    {
        try
        {
            var role = await this._roleManager.FindByIdAsync(id);

            if (role == null) return this._response.NotFoundResponse("Role does not exists");

            return this._response.OkResponse("", role);
        }
        catch (Exception e)
        {

            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetRoles()
    {
        try
        {
            var roles = await this._roleManager.Roles.ToListAsync();

            return this._response.OkResponse("", roles);
        }
        catch (Exception e)
        {

            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }
}
