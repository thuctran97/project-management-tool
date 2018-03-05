using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin u)
        {
            if (ModelState.IsValid)
            {
                using (QLDAEntities en = new QLDAEntities())
                {
                    var v = en.UserLogins.Where(a => a.Account.Equals(u.Account) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserAccount"] = v.Account.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }
        public ActionResult AfterLogin()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserLogin u, string cmPass)
        {
            if (ModelState.IsValid)
            {
                if (u.Password!=cmPass)
                {
                    ViewBag.Message = "Mật khẩu xác nhận không đúng";
                    return View();
                } else
                using (QLDAEntities en = new QLDAEntities())
                {
                        u.Id = "U004";
                        en.UserLogins.Add(u);
                        en.SaveChanges();
                        ViewBag.Message = "Đăng kí thành công";
                        return View();
                }
               
            }
            return View();

        }
    }
}