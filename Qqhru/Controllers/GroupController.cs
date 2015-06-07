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
    }
}