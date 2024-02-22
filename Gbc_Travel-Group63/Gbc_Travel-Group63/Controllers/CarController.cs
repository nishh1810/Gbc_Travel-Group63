﻿using Gbc_Travel_Group63.Data;
using Gbc_Travel_Group63.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gbc_Travel_Group63.Controllers
{
    public class CarController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Cars.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car project)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Add(project);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }
        public IActionResult Edit(int id)
        {
            var project = _db.Cars.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProjectId, Name, Description")] Car project)
        {
            if (id != project.Id)
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
                    if (!ProjectExists(project.Id))
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

        private bool ProjectExists(int id)
        {
            return _db.Cars.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var project = _db.Cars.FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ProjectId)
        {
            var project = _db.Cars.Find(ProjectId);
            if (project != null)
            {
                _db.Cars.Remove(project);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Handle the case where the project might not be found
            return NotFound();
        }
    }
}
