using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qqhru.Models;

namespace Qqhru.Controllers
{
    [Authorize]
    public class TeacherController : BaseController
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            var user = DB.Users.Find(id);
            if (user == null) return Msg("没有找到该教师");
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Groups = DB.Groups.ToList();
            var user = DB.Users.Find(id);
            if (user == null) return Msg("没有找到该教师");
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id, string Name, Sex Sex, string Profession, int GroupID, Title Title)
        {
            var user = DB.Users.Find(id);
            user.Name = Name;
            user.Sex = Sex;
            user.Profession = Profession;
            user.GroupID = GroupID;
            user.Title = Title;
            DB.SaveChanges();
            return Redirect("/Teacher/Show/" + id);
        }

        public ActionResult ResearchUpload(int id)
        {

        }
    }
}