using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Qqhru.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password, string returnUrl)
        {
            var user = (from u in DB.Users
                        where u.Username == Username
                        && u.Password == Password
                        select u).SingleOrDefault();
            if (user == null)
            {
                return Msg("用户名或密码错误！");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(Username, false);
                return Redirect(returnUrl ?? "/");
            }
        }
    }
}