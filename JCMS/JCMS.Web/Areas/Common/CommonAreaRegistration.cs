using System.Web.Mvc;

namespace JCMS.Web.Areas.Common
{
    public class CommonAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Common";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Common_default",
                "Common/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}