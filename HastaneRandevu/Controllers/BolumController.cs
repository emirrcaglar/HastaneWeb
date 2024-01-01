using HastaneRandevu.Models;
using HastaneRandevu.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevu.Controllers
{
    public class BolumController : Controller
    {
        private readonly IBolumRepository _bolumRepository;
        public BolumController(IBolumRepository context)
        {
            _bolumRepository = context;
        }
        public IActionResult Index()
        {
            List<Bolum> objBolumList = _bolumRepository.GetAll().ToList();
            return View(objBolumList);
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Ekle()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Ekle(Bolum bl)
        {
            if (ModelState.IsValid)
            {
                _bolumRepository.Ekle(bl);
                _bolumRepository.Kaydet();
                TempData["basarili"] = "Yeni Bolum Basariyla Eklendi";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            Bolum? bolumVt = _bolumRepository.Get(u=>u.Id==id);
            if(bolumVt == null)
            {
                return NotFound();
            }
            return View(bolumVt);
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Guncelle(Bolum bl)
        {
            if (ModelState.IsValid)
            {
                _bolumRepository.Guncelle(bl);
                _bolumRepository.Kaydet();
                TempData["basarili"] = "Bolum Basariyla Guncellendi";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Bolum? bolumVt = _bolumRepository.Get(u => u.Id == id);
            if (bolumVt == null)
            {
                return NotFound();
            }
            return View(bolumVt);
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Bolum? bl = _bolumRepository.Get(u => u.Id == id);
            if(bl == null)
            {
                return NotFound();
            }
            _bolumRepository.Sil(bl);
            _bolumRepository.Kaydet();
            TempData["basarili"] = "Bolum Basariyla Silindi";
            return RedirectToAction("Index");
        }
    }
}
