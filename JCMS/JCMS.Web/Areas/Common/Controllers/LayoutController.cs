using JCmsErp.Meuns;
using JCmsErp.Web.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCmsErp.Web.Areas.Common.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IMeunService _iMeunService;
        public LayoutController(IMeunService iMeunService) {
            _iMeunService = iMeunService;
        }
        List<MeunDto> modules = new List<MeunDto>();

        public ActionResult _LeftSideMenus()
        {
            MeunViewModel model = new MeunViewModel();
            List<MeunDto> modules = _iMeunService.GetMeunList();
            model._LPBasicSet = modules;
            return PartialView("_LeftSideMenus", model);
        }

        public ActionResult _Layout()
        {
             List<MeunDto> modules = _iMeunService.GetMeunList();
            ViewBag.SidebarMenuModel = modules;
            return View();
        }
     
        public ActionResult _MainFooter()
        {
            return PartialView("_MainFooter");
        }
        public ActionResult _MainHeader()
        {
            return PartialView("_MainHeader");
        }

    }
}