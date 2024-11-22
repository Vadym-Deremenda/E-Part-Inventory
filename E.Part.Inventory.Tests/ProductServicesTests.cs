

using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace E.Part.Inventory.Tests;

public class ProductServicesTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly DbContextOptions<EPartInventoryContext> _dbContextOptions;

    public ProductServicesTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dbContextOptions = new DbContextOptionsBuilder<EPartInventoryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetAllProductsAsync_ReturnsAllProducts()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        context.Products.Add(new Product { Id = 1, ProductName = "Product 1" });
        context.Products.Add(new Product { Id = 2, ProductName = "Product 2" });
        context.SaveChanges();

        var service = new ProductServices(context, _mapperMock.Object);

        // Act
        var result = await service.GetAllProductsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetProductAsync_ExistingId_ReturnsProduct()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        var product = new Product { Id = 1, ProductName = "Product 1" };
        context.Products.Add(product);
        context.SaveChanges();

        var service = new ProductServices(context, _mapperMock.Object);

        // Act
        var result = await service.GetProductAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Product 1", result.ProductName);
    }

    [Fact]
    public async Task AddProductAsync_AddsProduct()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        var service = new ProductServices(context, _mapperMock.Object);
        var product = new Product { Id = 1, ProductName = "New Product" };

        // Act
        await service.AddProductAsync(product);

        // Assert
        Assert.Equal(1, context.Products.Count());
    }
}
