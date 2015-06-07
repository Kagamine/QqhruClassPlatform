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

        public ActionResult Show(int id)
        {
            var article = DB.Articles.Find(id);
            if (article == null) return Msg("没有找到文章！");
            return View(article);
        }

        public ActionResult Create()
        {
            ViewBag.Catalogs = DB.Catalogs.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(string Title, int CatalogID, string Content)
        {
            DB.Articles.Add(new Models.Article {
                CatalogID = CatalogID,
                Content = Content,
                UserID = CurrentUser.ID,
                Time = DateTime.Now,
                Title = Title,
                Show = CurrentUser.Role == Models.UserRole.老师 ? false : true
            });
            DB.SaveChanges();
            if (CurrentUser.Role == Models.UserRole.老师) return Msg("文章发布成功，请等待管理员审核，审核通过后将显示在文章资源列表中。");
            else return Redirect("/");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Login");
        }
    }
}