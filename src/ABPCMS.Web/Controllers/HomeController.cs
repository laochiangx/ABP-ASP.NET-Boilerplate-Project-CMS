using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace ABPCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ABPCMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}