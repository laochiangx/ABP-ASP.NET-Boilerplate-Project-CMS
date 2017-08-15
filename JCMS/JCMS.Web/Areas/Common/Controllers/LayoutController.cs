using Abp.Auditing;
using JCms.Meuns;
using JCMS.Web.Areas.Common.Models;
using JCMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCMS.Web.Areas.Common.Controllers
{
    public class LayoutController : JCMSControllerBase
    {
        private readonly IMeunService _iMeunService;
        public LayoutController(IMeunService iMeunService)
        {
            _iMeunService = iMeunService;
        }
        // GET: Common/Layout
        public ActionResult Index()
        {
            return View();
        }
        List<MeunDto> modules = new List<MeunDto>();

        [DisableAuditing]
        public ActionResult _Layout()
        {
            List<MeunDto> modules = _iMeunService.GetMeunList();
            ViewBag.SidebarMenuModel = modules;
            return View();
        }
        [DisableAuditing]
        public ActionResult _LeftSideMenus()
        {
            MeunViewModel model = new MeunViewModel();
            List<MeunDto> modules = _iMeunService.GetMeunList();
            model._LPBasicSet = modules;
            return PartialView("_LeftSideMenus", model);
        }
        [DisableAuditing]
        public ActionResult _MainFooter()
        {
            return PartialView("_MainFooter");
        }
        [DisableAuditing]
        public ActionResult _MainHeader()
        {
            return PartialView("_MainHeader");
        }
    }
}