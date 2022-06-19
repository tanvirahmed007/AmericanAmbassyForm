using AmericanAmbassyForm.Data;
using AmericanAmbassyForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmericanAmbassyForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AmericanAmbassyDBContex americanAmbassyDBContex;
        public HomeController(ILogger<HomeController> logger, AmericanAmbassyDBContex americanAmbassyDBContex)
        {
            _logger = logger;
            this.americanAmbassyDBContex = americanAmbassyDBContex;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormInformation info)
        {
            americanAmbassyDBContex.FormInformations.Add(info);
            americanAmbassyDBContex.SaveChanges();

            return View();
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
}