using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GetandTake.Models.DTOs.BaseDTO;

public class ProductDTO 
{
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; }

    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public int? UnitsOnOrder { get; set; }

    public int? ReorderLevel { get; set; }

    [Required]
    public bool Discontinued { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }
}
