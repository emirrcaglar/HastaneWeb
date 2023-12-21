using HastaneRandevu.Models;
using HastaneRandevu.Utility;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class DoktorController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        public DoktorController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            List<Doktor> objDoktorList = _uygulamaDbContext.doktorlar.ToList();
            return View(objDoktorList);
        }

        public IActionResult DoktorEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DoktorEkle(Doktor dt)
        {
            _uygulamaDbContext.doktorlar.Add(dt);
            _uygulamaDbContext.SaveChanges();
            return View();
        }
    }
}
