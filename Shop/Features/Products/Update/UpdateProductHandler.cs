using Mediator;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Infrastructure;

namespace Shop.Features.Products.Update;

/// <summary>
/// Represents a handler for updating products.
/// </summary>
public class UpdateProductHandler(IShopDbContext shopDbContext) : IRequestHandler<UpdateProductCommand, Product?>
{
    /// <inheritdoc />
    public async ValueTask<Product?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await shopDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);
        if (product is null)
            return null;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Modified = DateTime.UtcNow;
        await shopDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return product;
    }
}
