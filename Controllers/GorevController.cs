using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using İnsanK.Models;
namespace İnsanK.Controllers
{

    public class GorevController : Controller
    {
        İnsanKaynaklarıEntities db = new İnsanKaynaklarıEntities();
        // GET: Gorev
        public ActionResult Index2()
        {
            var gorevler = db.tblGörev.ToList();
            return View(gorevler);
        }
        [HttpGet]
        public ActionResult GorevEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GorevEkle(tblGörev g)
        {
            db.tblGörev.Add(g);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult GorevSil(int id)
        {
            var gorev = db.tblGörev.Find(id);
            db.tblGörev.Remove(gorev);
            _=db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult GorevGetir(int id)
        {
            var grv = db.tblGörev.Find(id);
            return View("GorevGetir", grv);
        }
        public ActionResult GorevGuncelle(tblGörev g)
        {
            var grv = db.tblGörev.Find(g.GörevİD);
            grv.GörevİD = g.GörevİD;
            grv.Görevadı = g.Görevadı;            
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}