using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;

namespace MvsStok.Controllers
{
    public class MusteriController : Controller
    {
        MvsDbStokEntities db = new MvsDbStokEntities();
        
        public ActionResult Index()
        {
            var urundeger = db.TBLMUSTERI.ToList();
            return View(urundeger);
        }
        [HttpGet]
        public ActionResult musteriekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult musteriekle(TBLMUSTERI m1)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.TBLMUSTERI.Add(m1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult sil(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musteriGetir(int id)
        {
          
            var mstr = db.TBLMUSTERI.Find(id);
            return View("musteriGetir",mstr);
        }
        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var msr = db.TBLMUSTERI.Find(p1.MUSTERIID);
            msr.MUSTERIAD=p1.MUSTERIAD;
            msr.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction ("Index");
            
        }
    }
}