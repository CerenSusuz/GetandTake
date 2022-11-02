using GetandTake.Controller;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Moq;

namespace UnitTests;

public class UnitTestController
{
    [Fact]
    public Task ProductList_ShouldExecuteSuccessullyAndReturnProducts()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productList = GetProductsAsync();
        productService.Setup(product => product.GetAllAsync())
            .Returns(productList);
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.ProductList();

        //assert
        Assert.NotNull(productResult);
        Assert.Equal(productList.Result.Count, productResult.Result.Count);
        Assert.Equal(productList.ToString(), productResult.ToString());
        return Task.CompletedTask;
    }

    [Fact]
    public Task Product_ShouldExecuteSuccessullyAndReturnProduct()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productList = GetProductsAsync().Result;
        productService.Setup(product => product.GetByIdAsync(2).Result)
            .Returns(productList[1]);
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.GetProductByIdAsync(2);

        //assert
        Assert.NotNull(productResult);
        Assert.Equal(productList[1].ProductID, productResult.Result.ProductID);
        Assert.True(productList[1].ProductID == productResult.Result.ProductID);
        
        return Task.CompletedTask;
    }

    [Fact]
    public void IndexOf_NullProduct_ThrowsArgumentNullException()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productToFind = new ProductsDTO();
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.ProductList();

        //assert
        Assert.Throws<NullReferenceException>(() =>
        {
            int index = productResult.Result.IndexOf(productToFind);
        });
    }

    private static Task<List<ProductsDTO>> GetProductsAsync()
    {
        List<ProductsDTO> products = new()
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

            new ProductsDTO
            {
                ProductID = 2,
                ProductName = "Chang",
                Supplier = "Nord-Ost-Fisch Handelsgesellschaft mbH",
                Category  = "Dairy Products",
                QuantityPerUnit = "24 - 12 oz bottles",
                UnitPrice = 19,
                UnitsInStock = 17,
                UnitsOnOrder = 40,
                ReorderLevel = 25,
                Discontinued = false
            },

            new ProductsDTO
            {
                ProductID = 3,
                ProductName = "Testing",
                Supplier = null,
                Category  = null,
                QuantityPerUnit = null,
                UnitPrice = null,
                UnitsInStock = null,
                UnitsOnOrder = null,
                ReorderLevel = null,
                Discontinued = false
            },
        };

        return Task.FromResult(products);
    }
}

