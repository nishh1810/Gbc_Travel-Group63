using Microsoft.AspNetCore.Mvc;
using Gbc_Travel_Group63.Models;
using Gbc_Travel_Group63.Data;

namespace Gbc_Travel_Group63.Controllers
{
    
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

    public CarController (ApplicationDbContext context)
    {
        _context = context;
    }

        public IActionResult Index()
        {
            var cars = _context.Cars.ToList();
        return View(cars);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
    public async Task<IActionResult> Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }
    }
}
