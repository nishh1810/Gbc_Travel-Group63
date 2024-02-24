// FlightsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Gbc_Travel_Group63.Models;
using Gbc_Travel_Group63.Data;

public class FlightsControllercs : Controller
{
    private readonly ApplicationDbContext _context;

    public FlightsControllercs(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var flights = _context.Flights.ToList();
        return View(flights);
    }

    public IActionResult Book(int id)
    {
        var flight = _context.Flights.Find(id);

        // Redirect to the BookingDetails action in the BookingController
        return RedirectToAction("Book", "Booking", new { bookingType = "Flight", itemId = id });
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Flights flight)
    {
        if (ModelState.IsValid)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }
}
