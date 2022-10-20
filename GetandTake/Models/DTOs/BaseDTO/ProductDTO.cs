using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Models.DTOs.BaseDTO;

public class ProductDTO 
{
    [Required]
    [DisplayName("Product Name")]
    public string ProductName { get; set; }

    [DisplayName("Quantity per Unit")]
    public string QuantityPerUnit { get; set; }

    [DisplayName("Unit Price")]
    public decimal? UnitPrice { get; set; }

    [DisplayName("Quantity per Unit")]
    public int? UnitsInStock { get; set; }

    public int? UnitsOnOrder { get; set; }

    public int? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }
}
