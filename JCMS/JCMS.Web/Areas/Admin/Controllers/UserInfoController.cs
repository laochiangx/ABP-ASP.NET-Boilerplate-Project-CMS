using JCMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCMS.Web.Areas.Admin.Controllers
{
    public class UserInfoController : JCMSControllerBase
    {
        // GET: Admin/UserInfo
        public ActionResult Index()
        {
            return View();
        }
    }
}