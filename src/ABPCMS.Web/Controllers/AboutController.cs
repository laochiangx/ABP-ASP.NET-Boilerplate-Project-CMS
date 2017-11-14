using System.Web.Mvc;

namespace ABPCMS.Web.Controllers
{
    public class AboutController : ABPCMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}