using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Shop.Common.Models;

namespace Shop.Domain;

/// <summary>
/// Represents a product.
/// </summary>
[Table("product"), Index(nameof(UserId))]
public class Product : IGuidModel, IAuditModel
{
    /// <inheritdoc />
    [Column("created")]
    public DateTime Created { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the product description.
    /// </summary>
    [Column("description"), MaxLength(5000)]
    public string? Description { get; set; }

    /// <inheritdoc />
    [Column("id"), Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <inheritdoc />
    [Column("modified")]
    public DateTime Modified { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the product name.
    /// </summary>
    [Column("name"), MaxLength(1000)]
    public required string Name { get; set; }

    /// <summary>
    /// Gets whether this product is out of stock.
    /// </summary>
    [NotMapped]
    public bool OutOfStock => Stock <= 0;

    /// <summary>
    /// Gets or sets the product price.
    /// </summary>
    [Column("price")]
    public required decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the product stock.
    /// </summary>
    [Column("stock")]
    public required int Stock { get; set; }

    /// <inheritdoc />
    [Column("user_id"), MaxLength(36)]
    public required string UserId { get; set; }
}
