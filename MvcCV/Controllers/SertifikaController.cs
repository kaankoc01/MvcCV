using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertfikalarim>  repo = new GenericRepository<TblSertfikalarim> ();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.list();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        { 
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
            
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertfikalarim t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertfikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

    }
}