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
    public class ManageCountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageCountriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.DisplayCountries.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DisplayCountries model)
        {
            if (ModelState.IsValid)
            {
                _context.DisplayCountries.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var country = _context.DisplayCountries.FirstOrDefault(c => c.Id == id);
            _context.DisplayCountries.Remove(country);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
