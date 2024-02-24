using Microsoft.AspNetCore.Mvc;
using Gbc_Travel_Group63.Models;
using Gbc_Travel_Group63.Data;

namespace Gbc_Travel_Group63.Controllers
{
    public class HotelsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HotelsController (ApplicationDbContext context){
        _context = context;
        }

        public IActionResult Index()
        {
            var hotels = _context.Hotels.ToList();
        return View(hotels);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
    public async Task<IActionResult> Create(Hotel hotel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(hotel);
    }
    }
}
