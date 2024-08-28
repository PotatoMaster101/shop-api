namespace Shop.Api.Requests;

/// <summary>
/// Represents a request for updating a product.
/// </summary>
/// <param name="Name">The name of the product.</param>
/// <param name="Description">The description of the product.</param>
/// <param name="Price">The price of the product.</param>
public record UpdateProductRequest(string Name, string Description, decimal Price);
