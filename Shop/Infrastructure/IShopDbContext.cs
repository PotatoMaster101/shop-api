using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Infrastructure;

/// <summary>
/// Represents a DB context for storing shop items.
/// </summary>
public interface IShopDbContext
{
    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    DbSet<Product> Products { get; set; }

    /// <inheritdoc cref="DbContext.SaveChangesAsync(System.Threading.CancellationToken)"/>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
