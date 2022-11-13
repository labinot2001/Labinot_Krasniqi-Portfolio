using Labinot_Krasniqi_Portfolio.Data;
using Labinot_Krasniqi_Portfolio.Data.Services;
using Labinot_Krasniqi_Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Labinot_Krasniqi_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactServices _contactServices;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, IContactServices contactServices, AppDbContext context)
        {
            _logger = logger;
            _context=context;
            _contactServices=contactServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Current = "Contact";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact([Bind("FullName, Email, Subject, Message")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            await _contactServices.AddAsync(contact);
            ViewBag.Message = "Send Successfully";
           
            int id = contact.Id;
            return RedirectToAction("Details", new { id = id });
        }

        public async Task<IActionResult> Details(int id)
        {
            var contactDetails = await _contactServices.GetByIdAsync(id);

            if (contactDetails == null) return View("NotFound");
            return View(contactDetails);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
