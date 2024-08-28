namespace Shop.Api.Requests;

/// <summary>
/// Represents a request for creating a product.
/// </summary>
/// <param name="Name">The name of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="Price">The price of the product.</param>
/// <param name="Stock">The product stock.</param>
public record CreateProductRequest(string Name, string Description, decimal Price, int Stock);
