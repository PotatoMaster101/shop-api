using Shop.Domain;
using Shop.Features.Products.Create;

namespace Shop.Features.Products;

/// <summary>
/// Model mapper extensions.
/// </summary>
public static class ModelMapper
{
    /// <summary>
    /// Maps a <see cref="CreateProductCommand"/> to <see cref="Product"/>.
    /// </summary>
    /// <param name="model">The <see cref="CreateProductCommand"/> to map.</param>
    /// <returns>The mapped <see cref="Product"/>.</returns>
    public static Product ToDomain(this CreateProductCommand model)
    {
        return new Product
        {
            Description = model.Description,
            Name = model.Name,
            Price = model.Price,
            Stock = model.Stock,
            UserId = model.UserId,
        };
    }
}
