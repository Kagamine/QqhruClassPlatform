using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Qqhru.Models;

namespace Qqhru.Controllers
{
    public class BaseController : Controller
    {
        public readonly QqhruContext DB = new QqhruContext();
        public User CurrentUser = null;
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = (from u in DB.Users
                               where u.Username == User.Identity.Name
                               select u).Single();
                ViewBag.CurrentUser = CurrentUser;
            }
        }

        public ActionResult Msg(string msg)
        {
            return RedirectToAction("Message", "Shared", new { msg = msg });
        }
    }
}