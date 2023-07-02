using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using İnsanK.Models;

namespace İnsanK.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        İnsanKaynaklarıEntities db = new İnsanKaynaklarıEntities();
        public ActionResult Index()
        {
            var personeller = db.TblPersonel.ToList();
            return View(personeller);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel p)
        {
            db.TblPersonel.Add(p);
           _ = db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var per = db.TblPersonel.Find(id);
            return View("PersonelGetir" , per);
        }
        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var person = db.TblPersonel.Find(p.Personelİd);
            person.Adı = p.Adı;
            person.Soyadı = p.Soyadı;
            person.Tcno = p.Tcno;
            person.Telno = p.Telno;
            person.Görev = p.Görev;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}