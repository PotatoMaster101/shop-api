using Mediator;
using Shop.Domain;

namespace Shop.Features.Products.Update;

/// <summary>
/// Represents a command for updating a <see cref="Product"/>.
/// </summary>
/// <param name="Id">The ID of the product.</param>
/// <param name="Name">The name of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="Price">The price of the product.</param>
public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<Product?>;
