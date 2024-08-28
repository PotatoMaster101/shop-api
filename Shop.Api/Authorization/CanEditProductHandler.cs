using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;

namespace Shop.Api.Authorization;

public class CanEditProductHandler(IShopDbContext shopDbContext, IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<CanEditProductRequirement>
{
    /// <inheritdoc />
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanEditProductRequirement requirement)
    {
        var route = httpContextAccessor.HttpContext?.GetRouteData();
        var idStr = route?.Values["id"]?.ToString();
        if (!Guid.TryParse(idStr, out var id))
            return;

        var product = await shopDbContext.Products.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
        if (product is null || context.User.IsInRole("Admin") || product.UserId == context.User.FindFirstValue(ClaimTypes.NameIdentifier))
            context.Succeed(requirement);
    }
}
