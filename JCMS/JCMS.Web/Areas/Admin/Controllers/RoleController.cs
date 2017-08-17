using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using JCMS.Roles;
using JCMS.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCMS.Web.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {

        private readonly IRoleAppService _roleAppService;

        public RoleController( IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View();
        }
        [DisableAbpAntiForgeryTokenValidation]
        [HttpGet]
        [DontWrapResult]
        public JsonResult GetUsersList()
        {
            string pageNumber = string.IsNullOrWhiteSpace(Request["pageNumber"]) ? "0" : Request["pageNumber"];
            string pageSize = string.IsNullOrWhiteSpace(Request["pageSize"]) ? "20" : Request["pageSize"];
            List<RoleDto> role = new List<RoleDto>();
            role = _roleAppService.GetAllList();
            int totaldata = role.Count();
            role = role.Skip(int.Parse(pageNumber) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            var result = new { total = totaldata, rows = role };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}