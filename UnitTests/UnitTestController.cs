using GetandTake.Controller;
using GetandTake.Models;
using GetandTake.Models.DTOs.BaseDTO;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests;
public class UnitTestController
{
    private readonly Mock<IProductService> productService;
	public UnitTestController()
	{
		productService = new Mock<IProductService>();
	}

	[Fact]
	public void GetProductItems_ProductList()
	{
        //arrange
        var productList = GetProductsData();
        productService.Setup(x => x.GetAllAsync())
            .Returns(productList);
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.ProductList();

        //assert
        Assert.NotNull(productResult);
        Assert.Equal(GetProductsData().Result.Count(), productResult.Result.Count());
        Assert.Equal(GetProductsData().ToString(), productResult.ToString());
    }

    private async Task<List<ProductsDTO>> GetProductsData()
    {
        List<ProductsDTO> productsData = new List<ProductsDTO>
        {
            new ProductsDTO
            {
                ProductID = 1,
                ProductName = "Chai",
                Supplier = "Nord-Ost-Fisch Handelsgesellschaft mbH",
                Category  = "Dairy Products",
                QuantityPerUnit = "10 boxes x 20 bags",
                UnitPrice = 3,
                UnitsInStock = 2,
                UnitsOnOrder = 10,
                ReorderLevel = 1,
                Discontinued = true
            },
        };
        return productsData;
    }
}

