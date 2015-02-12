using Mlm.Domain.Abstract.Database;
using Mlm.Web.Filter;
using Mlm.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Mlm.Web.Areas.Acount.Controllers
{
    [InitializeSimpleMembership]
    public class AcountController : Controller
    {
        //
        // GET: /Acount/Acount/
        IRepository _db;
    
        

        public AcountController(IRepository db)
        {
            _db = db;
           
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new UserLogin());
        }

        [HttpPost]
        public ActionResult Login(UserLogin model, string returnUrl)
        {
            //try
            //{
            //    WebSecurity.CreateUserAndAccount(model.Login, model.Password);
            //    if (ModelState.IsValid && WebSecurity.Login(model.Login, model.Password, true))
            //    {
            //        return Redirect(returnUrl);
            //    }
            //}
            //catch (Exception e)
            //{
                
            //}
            if(ModelState.IsValid)
            {
                if(Membership.ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return Redirect(returnUrl);
                }
            }
            return View(model);
        }

    }
}
