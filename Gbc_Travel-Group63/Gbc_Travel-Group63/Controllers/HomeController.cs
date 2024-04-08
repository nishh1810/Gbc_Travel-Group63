using Gbc_Travel_Group63.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Gbc_Travel_Group63.Data;


namespace Gbc_Travel_Group63.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
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

[Authorize]
        public IActionResult ViewUserBookings()
{
    // Get the current user
    var user = _userManager.GetUserAsync(User).Result;
    
    if (user != null)
    {
        // Query the database for bookings created by the current user
        var userBookings = _context.Bookings.Where(b => b.UserId == user.Id).ToList();
        
        // Pass the user's bookings to the view
        return View(userBookings);
    }
    
    // If the user is not found, return an error or redirect as appropriate
    return NotFound();
}

    }
}
