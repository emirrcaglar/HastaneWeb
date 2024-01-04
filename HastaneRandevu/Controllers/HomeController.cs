using HastaneRandevu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace HastaneRandevu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        public HomeController(ILogger<HomeController> logger,
             IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _stringLocalizer = localizer;
        }

        public IActionResult Index()
        {
            var localizedTitle = _stringLocalizer["Welcome"];
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
