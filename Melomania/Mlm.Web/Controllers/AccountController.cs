using Mlm.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mlm.Web.Filter;
using WebMatrix.WebData;
using Mlm.Domain.DataBase;
using System.Data.Entity.Infrastructure;

namespace Mlm.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }

    
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.Login, model.Password, true))
            {
                return Redirect(returnUrl);
            }
            return View(model);

        }

        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            return View(new RegisterModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model, string password_confirmation)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == password_confirmation)
                {
                    try
                    {
                        WebSecurity.CreateUserAndAccount(model.Login, model.Password,
                                new
                                {
                                    Information_Name = model.Name,
                                    Information_Surname = model.Surname,
                                    Information_Address = model.Address
                                });

                        WebSecurity.Login(model.Login, model.Password);
                        return RedirectToAction("Index", "Start");
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Passwords is not same!");
                }
                
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login");
        }

    }
}
