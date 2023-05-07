using ASPnet.Demo.Exploration.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPnet.Demo.Exploration.Mvc.Controllers
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
            List<string> names = new List<string>();
            if (TempData.ContainsKey("name1") && TempData.ContainsKey("name2"))
            {
                names.Add((TempData["name1"] as string)!);
                names.Add((string)TempData["name2"]!);

            }
            ViewData["Student"] = names;
            return View();
        }

        public IActionResult Privacy()
        {
            TempData["name1"] = "John Doe";
            TempData["name2"] = "Hema Das";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}