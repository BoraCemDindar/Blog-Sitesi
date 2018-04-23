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
    public class MakaleController : Controller
    {
        BlogContext ent = new BlogContext();
        public ActionResult Index()
        {
            Repository<Makale> repo = new Repository<Makale>(ent);
            return View(repo.GetAll());
        }
    }
}