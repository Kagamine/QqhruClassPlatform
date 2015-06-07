using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qqhru.Controllers
{
    [Authorize]
    public class GroupController : BaseController
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            var group = DB.Groups.Find(id);
            if (group == null) return Msg("没有找到这个课组");
            else return View(group);
        }

        public ActionResult Create()
        {
            var group = new Models.Group
            {
                Title = "新建课组",
                UserID = CurrentUser.ID,
                Description = "新建课组"
            };
            DB.Groups.Add(group);
            DB.SaveChanges();
            return Redirect("/Group/Edit/" + group.ID);
        }

        public ActionResult Edit(int id)
        {
            var group = DB.Groups.Find(id);
            ViewBag.Users = DB.Users.ToList();
            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(int id, string Title, int UserID, string Description)
        {
            var group = DB.Groups.Find(id);
            group.Title = Title;
            group.UserID = UserID;
            group.Description = Description;
            DB.SaveChanges();
            return Redirect("/Group/Show/" + id);
        }
    }
}