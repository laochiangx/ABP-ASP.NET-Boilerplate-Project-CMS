using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace JCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : JCMSControllerBase
    {
        public ActionResult Index()
        {
            // return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
            return View("/Admin/UserInfo/Index");//C:\Users\jiangcy\Desktop\JCMS\JCMS.Web\Areas\Admin\Views\UserInfo\Index.cshtml
           
        }
	}
}