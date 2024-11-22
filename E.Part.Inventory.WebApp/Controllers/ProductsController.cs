using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductServices _productServices;

        public ProductsController(ProductServices _product)
        {
            _productServices = _product;
        }

        public IActionResult Index()
        {
            return View(_productServices.GetAllProductsAsync().Result);
        }

        public IActionResult Details(int id) {
            return View(_productServices.GetProductAsync(id).Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) {
                _productServices.AddProductAsync(product).Wait();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_productServices.GetProductAsync(id).Result);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productServices.UpdateProductAsync(product).Wait();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            _productServices.DeleteProductAsync(id).Wait();
            return RedirectToAction("Index");
        }
    }
}
