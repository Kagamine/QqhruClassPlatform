using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qqhru.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult Check()
        {
            return View();
        }

        public ActionResult CheckPassed(int id)
        {
            var article = DB.Articles.Find(id);
            article.Show = true;
            DB.SaveChanges();
            return Redirect("/Admin/Check");
        }
    }
}