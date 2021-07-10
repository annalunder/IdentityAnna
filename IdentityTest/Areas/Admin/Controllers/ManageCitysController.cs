using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTest.Data;
using IdentityTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageCitysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageCitysController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.DisplayCities.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DisplayCities model)
        {
            if (ModelState.IsValid)
            {
                _context.DisplayCities.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var city = _context.DisplayCities.FirstOrDefault(c => c.Id == id);
            _context.DisplayCities.Remove(city);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
