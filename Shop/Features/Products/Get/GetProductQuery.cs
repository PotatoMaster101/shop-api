using Mediator;
using Shop.Domain;

namespace Shop.Features.Products.Get;

/// <summary>
/// Represents a command for getting a <see cref="Product"/>.
/// </summary>
/// <param name="Id">The ID of the product.</param>
public record GetProductQuery(Guid Id) : IRequest<Product?>;
