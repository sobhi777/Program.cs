using InsuranceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsuranceMVC.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceEntities _context;

        public InsureeController(InsuranceEntities context)
        {
            _context = context;
        }

        // GET: Insuree
        public IActionResult Index()
        {
            var insurees = _context.Insurees.ToList();
            return View(insurees);
        }

        // GET: Insuree/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);
                _context.Add(insuree);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(insuree);
        }

        private decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50m; // base

            // Age
            if (insuree.Age < 18) quote += 100;
            else if (insuree.Age <= 25) quote += 50;
            else quote += 25;

            // Car Year
            if (insuree.CarYear < 2000) quote += 25;
            else if (insuree.CarYear > 2015) quote += 25;

            // Car Make & Model
            if (insuree.CarMake.ToLower() == "porsche") quote += 25;
            if (insuree.CarModel.ToLower() == "911") quote += 25;

            // Speeding Tickets
            quote += insuree.SpeedingTickets * 10;

            // DUI
            if (insuree.HasDUI) quote *= 1.25m;

            // Full Coverage
            if (insuree.FullCoverage) quote *= 1.5m;

            return quote;
        }
    }
}
