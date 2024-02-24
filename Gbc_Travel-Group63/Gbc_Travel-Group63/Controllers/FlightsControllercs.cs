using Gbc_Travel_Group63.Data;
using Gbc_Travel_Group63.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gbc_Travel_Group63.Controllers
{
    public class FlightsControllercs : Controller
    {
        public readonly ApplicationDbContext _db;
        public FlightsControllercs(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Flights.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flights flights)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Add(flights);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flights);
        }
        private bool ProjectExists(int id)
        {
            return _db.Flights.Any(e => e.FlightNumber == id);
        }
        [HttpGet("FlightsControllercs/Edit/{id:int}", Name = "FlightsEdit")]
        public IActionResult Edit(int id)
        {
            var project = _db.Flights.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost("FlightsControllercs/Edit/{id:int}", Name = "FlightsEdit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FlightNumber,DepartureCity,ArrivalCity,DepartureDate,DepartureTime,ArrivalTime,NumberOfPassengers,Price")] Flights project)
        {
            if (id != project.FlightNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(project);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.FlightNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
        
        [HttpGet("FlightsControllercs/Delete/{id:int}",Name ="FlightsDelete")]
        public IActionResult Delete(int id)
        {
            var project = _db.Flights.FirstOrDefault(p => p.FlightNumber == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost("FlightsControllercs/DeleteConfirmed/{id:int}",Name ="FlightsDeleConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var project = _db.Flights.Find(id);
            if (project != null)
            {
                _db.Flights.Remove(project);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Handle the case where the project might not be found
            return NotFound();
        }
    }
}
