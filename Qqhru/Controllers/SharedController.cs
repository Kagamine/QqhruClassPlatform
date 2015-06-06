using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qqhru.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Message(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }
    }
}