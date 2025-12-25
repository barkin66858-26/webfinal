using Microsoft.AspNetCore.Mvc;
using FitnessApp.Models;
using FitnessApp.Data; // Ensure this using directive is present
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly FitnessDbContext _context;

        public PaymentController(FitnessDbContext context)
        {
            _context = context;
        }

        // Step 1: User Info Form
        public async Task<IActionResult> Subscribe(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null) return NotFound();

            var model = new SubscribeViewModel
            {
                PackageId = package.Id,
                PackageName = package.Name,
                PackagePrice = package.Price
            };
            return View(model);
        }

        // Step 1 POST: Validate and Move to Payment
        [HttpPost]
        public IActionResult Subscribe(SubscribeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Pass data to next view via ViewModel directly or TempData
                // For simplicity, we'll reconstruct the next model
                var paymentModel = new PaymentViewModel
                {
                    PackageId = model.PackageId,
                    PackageName = model.PackageName,
                    PackagePrice = model.PackagePrice,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };
                return View("Payment", paymentModel);
            }
            return View(model);
        }

        // Step 2 POST: Process Payment
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Eksik veya hatalı tuşlama yaptınız.");
                return View("Payment", model);
            }

            // Simulate Card Validation
            // Check if card number (stripped of spaces) is 16 digits
            var cleanCardNum = model.CardNumber.Replace(" ", "");
            if (cleanCardNum.Length != 16)
            {
                ModelState.AddModelError("CardNumber", "Kart bilgisi yanlış (16 hane olmalı).");
                return View("Payment", model);
            }

            // Simple check ensuring it's not a dummy "123..." sequence if desired, 
            // but the regex handles the format. Here we simulate a bank rejection.
            if (cleanCardNum.StartsWith("0000")) 
            {
                 ModelState.AddModelError("", "Kart bilgisi yanlış (Bankanız onaylamadı).");
                 return View("Payment", model);
            }

            // Save Member
            var newMember = new Member
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                PackageName = model.PackageName,
                PackagePrice = model.PackagePrice,
                RegistrationDate = DateTime.Now
            };

            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
