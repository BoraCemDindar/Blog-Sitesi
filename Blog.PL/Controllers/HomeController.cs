using Blog.BLL.DataModel;
using Blog.DAL.Context;
using Blog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.PL.Controllers
{
    public class HomeController : Controller
    {
        BlogContext ent = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SonMakaleler()
        {
            Repository<Makale> repo = new Repository<Makale>(ent);
            return PartialView(repo.GetAll(null, m => m.OrderByDescending(x => x.Tarih)).Take(3).ToList());
        }
        public ActionResult SonYorumlar()
        {
            Repository<Yorum> repo = new Repository<Yorum>(ent);
            return PartialView(repo.GetAll(null, y => y.OrderByDescending(x => x.Tarih)).Take(3).ToList());
        }
        public ActionResult CokKullanilanEtiketler()
        {
            Repository<Etiket> repo = new Repository<Etiket>(ent);
            return PartialView(repo.GetAll(null, e => e.OrderByDescending(x => x.Makaleler.Count())).Take(5).ToList());
        }
        public ActionResult MakaleFromYorum(int makaleID)
        {
            Repository<Makale> repo = new Repository<Makale>(ent);
            var makale = repo.Get(makaleID);
            return View(makale);
        }
        public ActionResult MakalelerByEtiket(int etiketID)
        {
            Repository<Etiket> repo = new Repository<Etiket>(ent);
            return View(repo.Get(e => e.ID == etiketID).Makaleler.ToList());
        }
    }
}