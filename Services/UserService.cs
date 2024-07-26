using Microsoft.AspNetCore.Identity;

namespace GymApi;

public class UserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly GenericsResponse _response;
    private readonly ILogger<UserService> _logger;

    public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, GenericsResponse response, ILogger<UserService> logger)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._response = response;
        this._logger = logger;
    }

    public async Task<BaseReponse> AsignRole(AsingRoleDto asingRole)
    {
        try
        {
            var role = await this._roleManager.FindByNameAsync(asingRole.Role.ToUpper());

            if (role == null) return this._response.BadRequestResponse("Role does not exists");

            var user = await this._userManager.FindByEmailAsync(asingRole.Email);

            if (user == null) return this._response.BadRequestResponse("User does not exists");

            var resultAsignRole = await this._userManager.AddToRoleAsync(user, asingRole.Role);

            if (!resultAsignRole.Succeeded) return this._response.BadRequestResponse("Error trying to asign role", resultAsignRole.Errors);

            return this._response.OkResponse($"Role asigned to {user.Email} successfully.");
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }

    }
}
