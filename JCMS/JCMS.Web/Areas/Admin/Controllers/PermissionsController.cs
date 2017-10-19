using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using JCms.Meuns;
using JCMS.Meuns;
using JCMS.Permissionse;
using JCMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCMS.Web.Areas.Admin.Controllers
{
    public class PermissionsController : JCMSControllerBase
    {
        private readonly IPermissionService _iPermissionService;

        public PermissionsController(IPermissionService iPermissionService)
        {
            _iPermissionService = iPermissionService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [DisableAbpAntiForgeryTokenValidation]
        [HttpGet]
        [DontWrapResult]
        public  JsonResult GetUsersList()
        {
            string pageNumber = string.IsNullOrWhiteSpace(Request["pageNumber"]) ? "0" : Request["pageNumber"];
            string pageSize = string.IsNullOrWhiteSpace(Request["pageSize"]) ? "20" : Request["pageSize"];
            List<PermissionDto> Permissionlist = new List<PermissionDto>();
            var Meun =  _iPermissionService.GetMeunList(); //Paging not implemented yet
            int totaldata = Meun.Count();
            Permissionlist = Meun.Skip(int.Parse(pageNumber) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            var result = new { total = totaldata, rows = Permissionlist };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}