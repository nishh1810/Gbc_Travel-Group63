using Gbc_Travel_Group63.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gbc_Travel_Group63.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Listing()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult GeneralSearch(string searchType)
        {
            if (searchType == "Hotels")
            {
               
                return RedirectToAction("HotelForm", "Home");
            }
            else if (searchType == "Flights")
            {
                
                return RedirectToAction("FlightForm", "Home");
            } 
            else if (searchType == "Cars")
            {
                
                return RedirectToAction("CarForm", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult FlightForm() { return View(); }
        public IActionResult CarForm() { return View(); }
        public IActionResult HotelForm() { return View(); }
    }
}
