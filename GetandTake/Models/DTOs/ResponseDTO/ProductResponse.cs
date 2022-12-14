namespace GetandTake.Models.DTOs.ResponseDTO;

public class ProductResponse
{
    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public string? Category { get; set; }

    public string? Supplier { get; set; }
}