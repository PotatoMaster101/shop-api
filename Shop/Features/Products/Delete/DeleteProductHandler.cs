using Mediator;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Infrastructure;

namespace Shop.Features.Products.Delete;

/// <summary>
/// Represents a handler for deleting products.
/// </summary>
public class DeleteProductHandler(IShopDbContext shopDbContext) : IRequestHandler<DeleteProductCommand, Product?>
{
    /// <inheritdoc />
    public async ValueTask<Product?> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await shopDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);
        if (product is null)
            return null;

        shopDbContext.Products.Remove(product);
        await shopDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return product;
    }
}
