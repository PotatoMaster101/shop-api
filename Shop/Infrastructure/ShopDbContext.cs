using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Infrastructure;

/// <inheritdoc cref="IShopDbContext"/>
public class ShopDbContext : DbContext, IShopDbContext
{
    /// <inheritdoc />
    public DbSet<Product> Products { get; set; }

    /// <inheritdoc />
    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options) { }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("shop");
    }
}
