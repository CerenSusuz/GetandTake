using GetandTake.Models.Base;

namespace GetandTake.Models.DTOs.BaseDTO
{
    public class ProductDTO : IBaseDTO
    {
        //use for Create,Update,Delete
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
}
