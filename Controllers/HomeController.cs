using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Models;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FitnessDbContext _context;

    public HomeController(ILogger<HomeController> logger, FitnessDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Packages()
    {
         var packages = await _context.Packages.ToListAsync();
         return View(packages);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
    
    public async Task<IActionResult> PackageDetails(int id)
    {
        var package = await _context.Packages.FindAsync(id);
        if (package == null) return NotFound();
        return View(package);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
