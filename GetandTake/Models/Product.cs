﻿using GetandTake.Core.Models;

namespace GetandTake.Models;

public class Product : BaseEntity
{
    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public string QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public int? SupplierID { get; set; }

    public Supplier Supplier { get; set; }

    public int? CategoryID { get; set; }

    public Category Category { get; set; }
}
