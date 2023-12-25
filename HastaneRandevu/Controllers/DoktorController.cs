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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DoktorController(IDoktorRepository doktorRepository, IBolumRepository bolumRepository, IWebHostEnvironment webHostEnvironment)
        {
            _doktorRepository = doktorRepository;
            _bolumRepository = bolumRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            // List<Doktor> objDoktorList = _doktorRepository.GetAll().ToList();
            List<Doktor> objDoktorList = _doktorRepository.GetAll(includeProps:"Bolum").ToList();
            return View(objDoktorList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> BolumList = _bolumRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.bolumAdi,
                Value = k.Id.ToString()
            });

            ViewBag.Bolum = BolumList;

            if(id == null || id == 0)
            {
                // Ekle
                return View();
            }
            else
            {
                // Guncelle
                Doktor? doktorVt = _doktorRepository.Get(u => u.Id == id);
                if (doktorVt == null)
                {
                    return NotFound();
                }
                return View(doktorVt);
            }
        }
        [HttpPost]
        public IActionResult EkleGuncelle(Doktor dt)
        {
            if (ModelState.IsValid)
            {
                if(dt.Id == 0)
                {
                    _doktorRepository.Ekle(dt);
                    TempData["basarili"] = "Yeni Doktor Basariyla Eklendi";

                }
                else
                {
                    _doktorRepository.Guncelle(dt);
                    TempData["basarili"] = "Doktor Basariyla Guncellendi";


                }
                _doktorRepository.Kaydet();
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
