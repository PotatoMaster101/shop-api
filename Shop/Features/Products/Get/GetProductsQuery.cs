using Mediator;
using Shop.Domain;

namespace Shop.Features.Products.Get;

/// <summary>
/// Represents a query for getting <see cref="Product"/>.
/// </summary>
public record GetProductsQuery : IRequest<IQueryable<Product>>;
