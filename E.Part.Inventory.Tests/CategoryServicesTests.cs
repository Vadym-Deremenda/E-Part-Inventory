using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace E.Part.Inventory.Tests;

public class CategoryServicesTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly DbContextOptions<EPartInventoryContext> _dbContextOptions;

    public CategoryServicesTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dbContextOptions = new DbContextOptionsBuilder<EPartInventoryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetAllCategoryAsync_ReturnsAllCategories()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        context.Categories.Add(new Category { Id = 1, CategoryName = "Category 1" });
        context.Categories.Add(new Category { Id = 2, CategoryName = "Category 2" });
        context.SaveChanges();

        var service = new CategoryServies(context, _mapperMock.Object);

        // Act
        var result = await service.GetAllCategoryAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetCategoryAsync_ExistingId_ReturnsCategory()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        var category = new Category { Id = 1, CategoryName = "Category 1" };
        context.Categories.Add(category);
        context.SaveChanges();

        var service = new CategoryServies(context, _mapperMock.Object);

        // Act
        var result = await service.GetCategoryAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Category 1", result.CategoryName);
    }

    [Fact]
    public async Task AddCategoryAsync_AddsCategory()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        var service = new CategoryServies(context, _mapperMock.Object);
        var category = new Category { Id = 1, CategoryName = "New Category" };

        // Act
        await service.AddCategoryAsync(category);

        // Assert
        Assert.Equal(1, context.Categories.Count());
    }

    [Fact]
    public async Task DeleteCategoryAsync_ExistingId_RemovesCategory()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        var category = new Category { Id = 1, CategoryName = "Category 1" };
        context.Categories.Add(category);
        context.SaveChanges();

        var service = new CategoryServies(context, _mapperMock.Object);

        // Act
        await service.DeleteCategoryAsync(1);

        // Assert
        Assert.Empty(context.Categories);
    }
}