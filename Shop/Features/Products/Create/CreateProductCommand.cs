using Mediator;
using Shop.Domain;

namespace Shop.Features.Products.Create;

/// <summary>
/// Represents a command for creating a <see cref="Product"/>.
/// </summary>
/// <param name="Name">The name of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="Price">The price of the product.</param>
/// <param name="Stock">The product stock.</param>
/// <param name="UserId">The user ID that created the product.</param>
public record CreateProductCommand(string Name, string Description, decimal Price, int Stock, string UserId) : IRequest<Product>;
