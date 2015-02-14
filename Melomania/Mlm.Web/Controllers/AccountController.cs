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
using Mlm.Domain.Abstract.Database;

namespace Mlm.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        IRepository _db;
        public AccountController(IRepository db)
        {
            _db = db;
        }
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

        public FileContentResult GetImage_By_UserId(int? id = null)
        {
            var model = _db.users
                .FirstOrDefault(x => id == null ? x.Id == WebSecurity.CurrentUserId : x.Id == id);
            
            if (model == null || model.Avatar == null || model.Avatar.Picture == null)
                return null;

            return File(model.Avatar.Picture, model.Avatar.MimeType);
        }

        public RedirectToRouteResult ChangeAvatar(HttpPostedFileBase image)
        {
            var item = _db.users
                        .FirstOrDefault(x => x.Id == WebSecurity.CurrentUserId);
            if(item == null)
                return RedirectToAction("Manage", "Profile");

            item.Avatar.Picture = new byte[image.ContentLength];

            image.InputStream.Read(item.Avatar.Picture, 0, image.ContentLength);
            item.Avatar.MimeType = image.ContentType;

            _db.SaveChange();
            return RedirectToAction("Index", "Profile");
        }

        public RedirectToRouteResult ChangePassword(ChangePasswordModel model)
        {
            if(ModelState.IsValid)
            {
                var item = _db.users
                            .FirstOrDefault(x => x.Id == WebSecurity.CurrentUserId);

                if(WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    TempData["Message"] = "Password is changed succesed!";
                    item.Password = model.NewPassword;
                    return RedirectToAction("Index", "Profile");
                }                
            }
            TempData["Message"] = "Password Is not changed!";
            return RedirectToAction("Manage", "Profile");
        }
    }
}
