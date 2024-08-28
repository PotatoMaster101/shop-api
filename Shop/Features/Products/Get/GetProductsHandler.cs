using Mediator;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Infrastructure;

namespace Shop.Features.Products.Get;

/// <summary>
/// Represents a handler for getting products.
/// </summary>
public class GetProductsHandler(IShopDbContext shopDbContext)
    : IRequestHandler<GetProductsQuery, IQueryable<Product>>,
      IRequestHandler<GetProductQuery, Product?>
{
    /// <inheritdoc />
    public ValueTask<IQueryable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(shopDbContext.Products.AsQueryable());
    }

    /// <inheritdoc />
    public async ValueTask<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await shopDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);
    }
}
