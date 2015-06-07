using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qqhru.Controllers
{
    [Authorize]
    public class ForumController : BaseController
    {
        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }
    }
}