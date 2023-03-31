using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;

namespace MvsStok.Controllers
{
    public class UrunlerController : Controller
    {
        MvsDbStokEntities db = new MvsDbStokEntities();
        // GET: Ürünler
        public ActionResult Index()
        {
            var urundeger = db.TBLURUN.ToList();
            return View(urundeger);
        }
        [HttpGet]
        public ActionResult urunekle()
        {
            ViewBag.kategoriler = db.TBLKATAGORI.ToList();
            
            return View();
        }
        [HttpPost]
        public ActionResult urunekle(TBLURUN u1)
        {
            db.TBLURUN.Add(u1);
            db.SaveChanges();       
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var urun= db.TBLURUN.Find(id);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urunGetir(int id)
        {
            var urn = db.TBLURUN.Find(id);
            return View("urunGetir", urn);
        }
        public ActionResult Guncelle(TBLURUN p1)
        {
            var urun = db.TBLURUN.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.URUNKATAGORI=p1.URUNKATAGORI;
            urun.FIYAT=p1.FIYAT;
            urun.MARKA=p1.MARKA;
            urun.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}