using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers;

[ApiController, Authorize(Policy = Constants.ApiKeyPolicy), Route("/api/setup"), Tags("Setup")]
public class SetupController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    : ControllerBase
{
    [HttpPost("admin")]
    public async Task<IActionResult> AddAdminUser()
    {
        // DANGER: in real app you would put admin creds into ENV variable or vault
        var adminUserConfig = configuration.GetRequiredSection("AdminUser");
        var adminRoleConfig = configuration.GetRequiredSection("AdminRole");
        var adminUserId = adminUserConfig["Id"]!;
        var adminRoleId = adminRoleConfig["Id"]!;
        if (await userManager.FindByIdAsync(adminUserId) != null)
            return Ok();

        var adminEmail = adminUserConfig["Email"]!;
        var adminRoleName = adminRoleConfig["Name"]!;
        var adminUser = new IdentityUser { Email = adminEmail, EmailConfirmed = true, Id = adminUserId, UserName = adminEmail };
        await userManager.CreateAsync(adminUser, adminUserConfig["Password"]!);
        await roleManager.CreateAsync(new IdentityRole { Id = adminRoleId, Name = adminRoleName });
        await userManager.AddToRoleAsync(adminUser, adminRoleName);
        return Ok();
    }
}
