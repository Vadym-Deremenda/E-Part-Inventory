using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Controllers
{
   
    public class CategoriesController : Controller
    {
        private readonly CategoryServies _categoryServices;

        public CategoriesController(CategoryServies categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            return View(_categoryServices.GetAllCategoryAsync().Result);
        }

        public IActionResult Details(int id) {
            return View(_categoryServices.GetCategoryAsync(id).Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid) {
                _categoryServices.AddCategoryAsync(category).Wait();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_categoryServices.GetCategoryAsync(id).Result);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.UpdateCategoryAsync(category).Wait();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            _categoryServices.DeleteCategoryAsync(id).Wait();
            return RedirectToAction("Index");
        }
    }
}
