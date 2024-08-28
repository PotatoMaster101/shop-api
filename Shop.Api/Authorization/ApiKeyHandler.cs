using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Authorization;

public class ApiKeyHandler(IHttpContextAccessor httpContextAccessor) : AuthorizationHandler<ApiKeyRequirement>
{
    /// <inheritdoc />
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
    {
        var apiKey = httpContextAccessor.HttpContext?.Request.Headers["X-API-KEY"].FirstOrDefault();
        if (apiKey is not null && apiKey == requirement.ApiKey)
            context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
