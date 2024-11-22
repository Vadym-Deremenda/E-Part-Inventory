using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.DTOs;
using E.Part.Inventory.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace E.Part.Inventory.Tests;

public class OrderServicesTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly DbContextOptions<EPartInventoryContext> _dbContextOptions;

    public OrderServicesTests()
    {
        _mapperMock = new Mock<IMapper>();
        _dbContextOptions = new DbContextOptionsBuilder<EPartInventoryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetOrderHistory_ReturnsMappedOrderHistory()
    {
        // Arrange
        using var context = new EPartInventoryContext(_dbContextOptions);
        var orders = new List<Order>
        {
            new Order { OrederId = 1, Total = 100, OrderDate = DateTime.Now },
            new Order { OrederId = 2, Total = 200, OrderDate = DateTime.Now }
        };

        context.Orders.AddRange(orders);
        context.SaveChanges();

        _mapperMock.Setup(m => m.Map<List<OrderHistoryDto>>(It.IsAny<List<Order>>()))
            .Returns(new List<OrderHistoryDto>
            {
                new OrderHistoryDto { OrderId = 1, Total = 100 },
                new OrderHistoryDto { OrderId = 2, Total = 200 }
            });

        var service = new OrderServices(context, _mapperMock.Object);

        // Act
        var result = await service.GetOrderHistory();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(100, result.First().Total);
    }
}
