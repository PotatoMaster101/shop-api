using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Authorization;

public record CanEditProductRequirement : IAuthorizationRequirement;
