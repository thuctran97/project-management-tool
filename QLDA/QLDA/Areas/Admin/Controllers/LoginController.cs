using Model;
using QLDA.Areas.Admin.Code;
using QLDA.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDA.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.Account, model.Password);
            if (result && ModelState.IsValid) {
                SessionHelper.SetSession(new UserSession() { Account = model.Account });
                return RedirectToAction("Index", "Home");
            } else{
                ModelState.AddModelError("", "Ten dang nhap hoac mat khau khong dung");

            }
            return View(model);
        }
        
    }
}