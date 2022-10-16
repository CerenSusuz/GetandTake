namespace GetandTake.Models.DTOs.BaseDTO;

public class ProductDTO 
{
    public string ProductName { get; set; }

    public string? QuantityPerUnit { get; set; }

    public int? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public int? UnitsOnOrder { get; set; }

    public int? ReorderLevel { get; set; }

    public bool? Discontinued { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }
}
