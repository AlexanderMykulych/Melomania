using System.Web.Mvc;

namespace Mlm.Web.Areas.Acount
{
    public class AcountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Acount";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Acount_default",
                "Acount/{controller}/{action}/{id}",
                new { action = "Login", controller = "Acount", id = UrlParameter.Optional }
            );
        }
    }
}
