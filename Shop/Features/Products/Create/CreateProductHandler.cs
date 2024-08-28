using Mediator;
using Shop.Domain;
using Shop.Infrastructure;

namespace Shop.Features.Products.Create;

/// <summary>
/// Represents a handler for creating products.
/// </summary>
public class CreateProductHandler(IShopDbContext shopDbContext) : IRequestHandler<CreateProductCommand, Product>
{
    /// <inheritdoc />
    public async ValueTask<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.ToDomain();
        await shopDbContext.Products.AddAsync(product, cancellationToken).ConfigureAwait(false);
        await shopDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return product;
    }
}
