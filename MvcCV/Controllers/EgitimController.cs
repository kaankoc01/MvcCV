using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

        // GET: Egitim

        public ActionResult Index()
        {
            var egitim = repo.list();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);

            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x=>x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDüzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDüzenle(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }

            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik1 = t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.Tarih = t.Tarih;
            egitim.GNO = t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }

    }
}