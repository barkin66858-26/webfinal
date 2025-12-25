using FitnessApp.Data;
using FitnessApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    [Authorize] // Simple check, ideally check for IsAdmin policy
    public class AdminController : Controller
    {
        private readonly FitnessDbContext _context;

        public AdminController(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var isAdmin = User.HasClaim(c => c.Type == "IsAdmin" && c.Value == "True");
            if (!isAdmin) return RedirectToAction("Index", "Home");

            var packages = await _context.Packages.ToListAsync();
            return View(packages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Package package)
        {
            if (ModelState.IsValid)
            {
                _context.Packages.Add(package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null) return NotFound();
            return View(package);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Package package)
        {
            if (ModelState.IsValid)
            {
                _context.Packages.Update(package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
