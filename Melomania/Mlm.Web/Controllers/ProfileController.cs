using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mlm.Web.Filter;
using WebMatrix.WebData;
using Mlm.Domain.Abstract.Database;
using Mlm.Web.Models;

namespace Mlm.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ProfileController : Controller
    {
        IRepository _db;
        //
        // GET: /Profile/
        public ProfileController(IRepository db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            ProfileModel model = null;
            try
            {
                model = new ProfileModel(_db.users.FirstOrDefault(x => x.Login == User.Identity.Name));
            }
            catch(Exception e)
            {

            }
          
            return View(model);            
        }

        public ActionResult Manage(int? id = null)
        {
            var model = _db.users
                .FirstOrDefault(x => id == null ? x.Id == WebSecurity.CurrentUserId : x.Id == id);

            if(model == null)
            {
                return View("Error");
            }
            
            return View(new ProfileModel(model));
        }

    }
}
