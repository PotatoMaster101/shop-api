using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure;

/// <inheritdoc cref="IAuthenticationDbContext"/>
public class AuthenticationDbContext : IdentityDbContext<IdentityUser>, IAuthenticationDbContext
{
    /// <inheritdoc />
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
        : base(options) { }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("identity");
    }
}
