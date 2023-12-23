using Microsoft.AspNetCore.Mvc.Rendering;
using HastaneRandevu.Models;
using HastaneRandevu.Utility;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class DoktorController : Controller
    {
        private readonly IDoktorRepository _doktorRepository;
        private readonly IBolumRepository _bolumRepository;
        public DoktorController(IDoktorRepository doktorRepository, IBolumRepository bolumRepository)
        {
            _doktorRepository = doktorRepository;
            _bolumRepository = bolumRepository;
        }
        public IActionResult Index()
        {
            List<Doktor> objDoktorList = _doktorRepository.GetAll().ToList();
            
            return View(objDoktorList);
        }

        public IActionResult Ekle()
        {
            IEnumerable<SelectListItem> BolumList = _bolumRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.bolumAdi,
                Value = k.Id.ToString()
            });

            ViewBag.Bolum = BolumList;

            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Doktor dt)
        {
            if (ModelState.IsValid)
            {
                _doktorRepository.Ekle(dt);
                _doktorRepository.Kaydet();
                TempData["basarili"] = "Yeni Doktor Basariyla Eklendi";
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
            Doktor? doktorVt = _doktorRepository.Get(u=>u.Id==id);
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
                _doktorRepository.Guncelle(dt);
                _doktorRepository.Kaydet();
                TempData["basarili"] = "Doktor Basariyla Guncellendi";
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
            Doktor? doktorVt = _doktorRepository.Get(u => u.Id == id);
            if (doktorVt == null)
            {
                return NotFound();
            }
            return View(doktorVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Doktor? dt = _doktorRepository.Get(u => u.Id == id);
            if(dt == null)
            {
                return NotFound();
            }
            _doktorRepository.Sil(dt);
            _doktorRepository.Kaydet();
            TempData["basarili"] = "Doktor Basariyla Silindi";
            return RedirectToAction("Index");
        }
    }
}
