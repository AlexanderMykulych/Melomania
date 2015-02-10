using Mlm.Domain.DataBase;
using Mlm.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mlm.Web.Controllers
{
    public class StartController : Controller
    {
        //
        // GET: /Start/
        DataBaseContext _db = new DataBaseContext();
        public ActionResult Index()
        {
            return View();
        }

    }
}
