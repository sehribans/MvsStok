using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;

namespace MvsStok.Controllers
{
    public class KatagoriController : Controller
    {
        // GET: Katagori
        MvsDbStokEntities db =new MvsDbStokEntities();
        public ActionResult Index()
        {
            var katagorideger = db.TBLKATAGORI.ToList();
            return View(katagorideger);
        }
        [HttpGet]
        public ActionResult katagoriekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult katagoriekle(TBLKATAGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View();
                //return View("katagoriekle");
            }
              db.TBLKATAGORI.Add(p1);
              db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult sil(int id)
        {
            var katagori = db.TBLKATAGORI.Find(id);
            db.TBLKATAGORI.Remove(katagori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult katagoriGetir(int id)
        {
            var ktg = db.TBLKATAGORI.Find(id);
            return View("katagoriGetir", ktg);
            
        }
        public ActionResult Guncelle(TBLKATAGORI p1)
        {
            var ktgr = db.TBLKATAGORI.Find(p1.KATAGORIID);
            ktgr.KATAGORIAD = p1.KATAGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}