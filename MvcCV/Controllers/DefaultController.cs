using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TblSosyalMedya.Where(x => x.Durum ==true).ToList();
            return PartialView(sosyalMedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertfikalarım()
        {
            var sertfika = db.TblSertfikalarim.ToList();
            return PartialView(sertfika);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            var iletisim = db.TblIletisim.ToList();
            return PartialView(iletisim);
        }
        [HttpPost]
        public PartialViewResult iletisim(TblIletisim t)
        {
            t.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}