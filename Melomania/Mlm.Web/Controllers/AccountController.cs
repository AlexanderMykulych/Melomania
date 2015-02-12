using Mlm.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mlm.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
           
            return View();

        }

        public ActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model, string password_confirmation)
        {
            return View(model);
        }

    }
}
