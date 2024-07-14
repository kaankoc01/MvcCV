using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.list();
            return View(mesajlar);
        }
    }
}