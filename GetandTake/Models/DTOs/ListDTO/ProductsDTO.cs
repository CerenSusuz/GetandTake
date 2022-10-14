namespace GetandTake.Models.DTOs.ListDTO
{
    public class ProductsDTO
    {
        //Use for Get
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public int? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool? Discontinued { get; set; }

        public string? Category { get; set; }
        public string? Supplier { get; set; }
    }
}
