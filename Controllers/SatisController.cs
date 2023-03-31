//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MvsStok.Models.Entity;

//namespace MvsStok.Controllers
//{
//    public class SatisController : Controller
//    {
//        MvsDbStokEntities db = new MvsDbStokEntities();

//        public ActionResult Index()
//        {
//            var urundeger = db.TBLSATIS.ToList();
//            return View(urundeger);
//        }
//    }
//}