using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Authorization;

public record ApiKeyRequirement(string ApiKey) : IAuthorizationRequirement;
