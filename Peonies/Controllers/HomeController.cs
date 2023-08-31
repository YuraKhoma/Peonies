using Microsoft.AspNetCore.Mvc;
using Peonies.Models;
using System.Diagnostics;

namespace Peonies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public IActionResult GetEditClient(int id)
        {
            ViewBag.ClientId = id;  
            return View();
        }

        public IActionResult GetDeleteClient(string name, int id)
        {
            ViewBag.ClientId = id;
            ViewBag.name = name;
            return View();
        }
        public IActionResult GetAddClient()
        {
            return View();
        }

        public IActionResult GetCreateOrder(int id)
        {
            ViewBag.ClientId = id;
            return View();
        }
    }
}