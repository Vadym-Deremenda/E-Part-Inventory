using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICrudRepository<Category> _repository;

        public CategoriesController(ICrudRepository<Category> repository)
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
        public IActionResult Create(Category category)
        {
            _repository.CreateAsync(category).Wait();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View("Create",_repository.GetByIdAsync(id).Result);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _repository.UpdateAsync(category).Wait();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            _repository.DeleteAsync(id).Wait();
            return RedirectToAction("Index");
        }
    }
}
