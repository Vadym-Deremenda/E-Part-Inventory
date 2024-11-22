using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Controllers
{
    public class AdminController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
