using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTest.Areas.Admin.Models;
using IdentityTest.Data;
using IdentityTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.User.Include(u => u.City).ThenInclude(c => c.Country).ToList();

            return View(users);
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.User.FirstOrDefault(u => u.Id == id);
           
            _context.User.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.User.Include(u => u.City).ThenInclude(c => c.Country)
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == id);
            var cities = _context.DisplayCities.ToList();
            ViewData["Cities"] = new SelectList(cities, "Name" ,"Name");
            var countries = _context.DisplayCountries.ToList();
            ViewData["Countries"] = new SelectList(countries, "Name", "Name");

            return View(user);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(EditUserViewModel model)
        {
            
            var user = _context.User.Include(u => u.City).ThenInclude(c => c.Country)
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == model.Id);
            if (ModelState.IsValid)
            {
                
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                if(model.CityName != null)
                    user.City.CityName = model.CityName;
                if(model.CountryName != null)
                    user.City.Country.CountryName = model.CountryName;
                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
