using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICrudRepository<Product> _repository;

        public ProductsController(ICrudRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetAllAsync().Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repository.CreateAsync(product).Wait();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View("Create",_repository.GetByIdAsync(id).Result);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repository.UpdateAsync(product).Wait();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            _repository.DeleteAsync(id).Wait();
            return RedirectToAction("Index");
        }
    }
}
