using AutoMapper;
using GetandTake.Controller;
using GetandTake.Models.DTOs.ListDTO;
using GetandTake.Services.Abstract;
using Moq;
using Xunit;

namespace UnitTests;

public class UnitTestController
{
    [Fact]
    public void ProductList_ShouldExecuteSuccessullyAndReturnProducts()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productList = GetProducts();
        productService.Setup(product => product.GetAllAsync())
            .ReturnsAsync(productList);
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.ProductList().Result;

        //assert
        Assert.NotNull(productResult);
        Assert.Equal(productList.Count, productResult.Count);
    }

    [Fact]
    public void Product_ShouldExecuteSuccessullyAndReturnProduct()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productList = GetProducts();
        productService.Setup(product => product.GetByIdAsync(2))
            .ReturnsAsync(productList[1]);
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.GetProductByIdAsync(2);

        //assert
        Assert.NotNull(productResult);
        Assert.Equal(productList[1].ProductID, productResult.Result.ProductID);
    }

    [Fact]
    public void Product_GetProductByIdWithInvalıdArguments_ThrowsArgumentException()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productList = GetProducts();
        productService.SetupSequence(product => product.GetByIdAsync(8))
            .ReturnsAsync(productList[1])
            .ThrowsAsync(new Exception());
        var productController = new ProductController(productService.Object);

        //act & assert
        Assert.ThrowsAsync<ArgumentException>(() => productController.GetProductByIdAsync(2));
    }

    [Fact]
    public void IndexOf_NullProduct_ThrowsArgumentNullException()
    {
        //arrange
        var productService = new Mock<IProductService>();
        var productToFind = new ProductsDTO();
        var productController = new ProductController(productService.Object);

        //act
        var productResult = productController.ProductList().Result;

        //assert
        Assert.Throws<NullReferenceException>(() =>
        {
            int index = productResult.IndexOf(productToFind);
        });
    }

    private static List<ProductsDTO> GetProducts()
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

        return products;
    }
}

