using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Model;
using NorthWindWebApp.Models;

namespace NorthWindWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _northwindContext;

        public HomeController(ILogger<HomeController> logger, NorthwindContext northwindContext)
        {
            _logger = logger;
            _northwindContext = northwindContext;
        }

        public IActionResult Index()
        {
            var cateogries = _northwindContext.Categories.ToList();
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
