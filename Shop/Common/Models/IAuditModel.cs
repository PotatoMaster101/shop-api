namespace Shop.Common.Models;

/// <summary>
/// Represents a model that can be audited.
/// </summary>
public interface IAuditModel
{
    /// <summary>
    /// Gets or sets the creation time.
    /// </summary>
    DateTime Created { get; set; }

    /// <summary>
    /// Gets or sets the modify time.
    /// </summary>
    DateTime Modified { get; set; }

    /// <summary>
    /// Gets or sets the creation user ID.
    /// </summary>
    string UserId { get; set; }
}
