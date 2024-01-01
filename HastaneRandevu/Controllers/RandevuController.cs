using Microsoft.AspNetCore.Mvc.Rendering;
using HastaneRandevu.Models;
using HastaneRandevu.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HastaneRandevu.Controllers
{
    

    public class RandevuController : Controller
    {
        private readonly IDoktorRepository _doktorRepository;
        private readonly IRandevuRepository _randevuRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RandevuController(IDoktorRepository doktorRepository, IRandevuRepository randevuRepository, IWebHostEnvironment webHostEnvironment)
        {
            _doktorRepository = doktorRepository;
            _randevuRepository = randevuRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Randevu> objRandevuList = _randevuRepository.GetAll(includeProps: "Doktor").ToList();
            return View(objRandevuList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> DoktorList = _doktorRepository.GetAll().Select(k => new SelectListItem
            {
                Text = $"{k.ad} {k.soyad}",
                Value = k.Id.ToString()
            });

            ViewBag.Doktor = DoktorList;

            if (id == null || id == 0)
            {
                // Ekle
                return View();
            }
            else
            {
                // Guncelle
                Randevu? randevuVt = _randevuRepository.Get(u => u.Id == id);
                if (randevuVt == null)
                {
                    return NotFound();
                }
                return View(randevuVt);
            }
        }
        [HttpPost]
        public IActionResult EkleGuncelle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                if (randevu.Id == 0)
                {
                    _randevuRepository.Ekle(randevu);
                    TempData["basarili"] = "Yeni Randevu Basariyla Alindi";

                }
                else
                {
                    _randevuRepository.Guncelle(randevu);
                    TempData["basarili"] = "Randevu Basariyla Guncellendi";


                }
                _randevuRepository.Kaydet();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            IEnumerable<SelectListItem> DoktorList = _doktorRepository.GetAll().Select(k => new SelectListItem
            {
                Text = $"{k.ad} {k.soyad}",
                Value = k.Id.ToString()
            });
            ViewBag.Doktor = DoktorList;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Randevu? randevuVt = _randevuRepository.Get(u => u.Id == id);
            if (randevuVt == null)
            {
                return NotFound();
            }
            return View(randevuVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Randevu? randevu = _randevuRepository.Get(u => u.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }
            _randevuRepository.Sil(randevu);
            _randevuRepository.Kaydet();
            TempData["basarili"] = "Randevu Basariyla Silindi";
            return RedirectToAction("Index");
        }
    }
}
