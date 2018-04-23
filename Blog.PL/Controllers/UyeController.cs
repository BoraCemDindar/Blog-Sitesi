using Blog.BLL.DataModel;
using Blog.DAL.Context;
using Blog.DAL.Repositories;
using Blog.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.PL.Controllers
{
    public class UyeController : Controller
    {
        BlogContext ent = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        //Tüm üyeleri View sayfasına (server -> client) json olarak döndürüyoruz.
        public JsonResult UyeListesi()
        {
            Repository<Uye> repo = new Repository<Uye>(ent);
            var liste = repo.GetAll();
            var listeModel = liste.Select(u => new UyeModel { adsoyad = u.Ad + " " + u.Soyad, email = u.Email }).ToList();
            return Json(listeModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost]
        public string UyeGiris(string Email, string Sifre)
        {
            Repository<Uye> repo = new Repository<Uye>(ent);
            Uye uye = repo.Get(u => u.Email == Email && u.Sifre == Sifre);
            if (uye == null) return "Hatalı Email yada Şifre girişi!";
            Session["uye"] = uye.ID;
            return "Hoşgeldiniz...<script type='text/javascript'>setTimeout(function(){window.location='/'}, 3000);</script>";
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Uye model)
        {
            Repository<Uye> repo = new Repository<Uye>(ent);
            if (ModelState.IsValid)  //Validation kontrolleri doğrulandı mı?
            {
                if (repo.Get(u => u.Email == model.Email) == null)
                {
                    Uye yeni = new Uye();
                    yeni.Ad = model.Ad;
                    yeni.Soyad = model.Soyad;
                    yeni.Email = model.Email;
                    yeni.Sifre = model.Sifre;
                    yeni.SifreTekrar = model.SifreTekrar;
                    yeni.Tarih = DateTime.Now;
                    if (repo.Add(yeni))
                        return RedirectToAction("UyeGiris");
                }else { ViewBag.Message = "Bu email zaten kayıtlı!"; }
            }
            return View();
        }
    }
}