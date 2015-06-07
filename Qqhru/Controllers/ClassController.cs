using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qqhru.Controllers
{
    [Authorize]
    public class ClassController : BaseController
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var cls = new Models.Class
            {
                Title = "新建课程",
                Plan = "",
                Plan2 = "",
                Term = "2015上",
                UserID = CurrentUser.ID
            };
            DB.Classes.Add(cls);
            DB.SaveChanges();
            return Redirect("/Class/Edit/" + cls.ID);
        }

        public ActionResult Edit(int id)
        {
            var cls = DB.Classes.Find(id);
            ViewBag.Users = DB.Users.ToList();
            return View(cls);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, string Plan, string Plan2, string Term, int UserID)
        {
            var cls = DB.Classes.Find(id);
            cls.Plan = Plan;
            cls.Plan2 = Plan2;
            cls.Term = Term;
            cls.UserID = UserID;
            DB.SaveChanges();
            return Redirect("/Class");
        }

        public ActionResult Plan(int id)
        {
            var cls = DB.Classes.Find(id);
            return View(cls);
        }

        public ActionResult Plan2(int id)
        {
            var cls = DB.Classes.Find(id);
            return View(cls);
        }
    }
}