using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Models.DTOs.DetailDTO;

public class ProductDetail
{
    [Required]
    [DisplayName("Product Name")]
    public string ProductName { get; set; }

    [DisplayName("Quantity per Unit")]
    public string QuantityPerUnit { get; set; }

    [DisplayName("Unit Price")]
    public decimal? UnitPrice { get; set; }

    [DisplayName("Units in Stock")]
    public int? UnitsInStock { get; set; }

    [DisplayName("UnitsOnOrder")]
    public int? UnitsOnOrder { get; set; }

    [DisplayName("ReorderLevel")]
    public int? ReorderLevel { get; set; }

    [DisplayName("Discontinued")]
    public bool Discontinued { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }
}