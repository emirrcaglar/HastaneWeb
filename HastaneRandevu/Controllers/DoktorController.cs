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
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.doktorlar.Add(dt);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            Doktor? doktorVt = _uygulamaDbContext.doktorlar.Find(id);
            if(doktorVt == null)
            {
                return NotFound();
            }
            return View(doktorVt);
        }
        [HttpPost]
        public IActionResult Guncelle(Doktor dt)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.doktorlar.Update(dt);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Doktor? doktorVt = _uygulamaDbContext.doktorlar.Find(id);
            if (doktorVt == null)
            {
                return NotFound();
            }
            return View(doktorVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Doktor? dt = _uygulamaDbContext.doktorlar.Find(id);
            if(dt == null)
            {
                return NotFound();
            }
            _uygulamaDbContext.doktorlar.Remove(dt);
            _uygulamaDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
