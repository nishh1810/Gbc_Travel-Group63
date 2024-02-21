using Microsoft.AspNetCore.Mvc;

namespace Gbc_Travel_Group63.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
