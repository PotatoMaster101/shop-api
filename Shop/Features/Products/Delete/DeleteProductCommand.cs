using Mediator;
using Shop.Domain;

namespace Shop.Features.Products.Delete;

/// <summary>
/// Represents a command for deleting a <see cref="Product"/>.
/// </summary>
/// <param name="Id">The ID of the product.</param>
public record DeleteProductCommand(Guid Id) : IRequest<Product?>;
