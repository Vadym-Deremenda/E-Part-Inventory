using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Controllers;

public class OrdersController:Controller
{
    private readonly OrderServices _orderServices;
    private readonly ProductServices _productServices;
    private readonly EPartInventoryContext _context;

    public OrdersController(OrderServices orderServices, ProductServices productServices, EPartInventoryContext context)
    {
        _orderServices = orderServices;
        _productServices = productServices;
        _context = context;
    }
    public IActionResult History()
    {
        return View(_orderServices.GetOrderHistory().Result);
    }

    public IActionResult Create()
    {
        var order = new Order
        {
            OrderDate = DateTime.Now,
            Total = 0
        };
        return View(order);
    }

    public JsonResult SearchProducts(string productCode)
    {
        var products = _context.Products
            .Where(p => p.ProductCode.Contains(productCode)) // Пошук за частиною ProductCode
            .Select(p => new
            {
                p.Id,
                p.ProductName,
                p.ProductCode,
                p.Price
            })
            .ToList();

        return Json(products);
    }

    // Збереження ордеру
    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (ModelState.IsValid)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(order);
    }
}