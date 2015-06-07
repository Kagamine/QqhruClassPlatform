using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
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
        public ActionResult Edit(int id, string Name, Sex Sex, string Profession, int? GroupID, Title Title)
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

        [HttpPost]
        public ActionResult ResearchUpload(int id, string Hint)
        {
            var File = Request.Files["file"];
            var research = new Research
            { 
                Hint = Hint,
                UserID = CurrentUser.ID,
                Time = DateTime.Now
            };
            if (File != null)
            {
                using (var binaryReader = new BinaryReader(File.InputStream))
                {
                    research.File = binaryReader.ReadBytes(File.ContentLength);
                    research.FileName = File.FileName;
                }
            }
            DB.Researches.Add(research);
            DB.SaveChanges();
            return Redirect("/Teacher/Show/" + id);
        }

        public ActionResult Research(int id)
        {
            var research = DB.Researches.Find(id);
            return File(research.File, "application/octet-stream", research.FileName);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Username, string Password, UserRole Role)
        {
            DB.Users.Add(new Models.User {
                Username = Username,
                Password = Password,
                Role = Role,
                Name = "新用户",
                Sex = Sex.男,
                Title = Title.助教,
                Profession = ""
            });
            DB.SaveChanges();
            return Redirect("/Teacher");
        }
    }
}