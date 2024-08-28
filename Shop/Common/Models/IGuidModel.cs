namespace Shop.Common.Models;

/// <summary>
/// Represents a model with a GUID as ID.
/// </summary>
public interface IGuidModel
{
    /// <summary>
    /// Gets or sets the model ID.
    /// </summary>
    Guid Id { get; set; }
}
