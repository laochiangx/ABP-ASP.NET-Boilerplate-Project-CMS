using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using JCms.Meuns;
using JCMS.Meuns;
using JCMS.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JCMS.Web.Areas.Admin.Controllers
{
    public class MeunController : JCMSControllerBase
    {
        private readonly IModulesService _iMeunService;

        public MeunController(IModulesService iMeunService)
        {
            _iMeunService = iMeunService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View();
        }
        [DisableAbpAntiForgeryTokenValidation]
        [HttpGet]
        [DontWrapResult]
        public async System.Threading.Tasks.Task<JsonResult> GetUsersListAsync()
        {
            string pageNumber = string.IsNullOrWhiteSpace(Request["pageNumber"]) ? "0" : Request["pageNumber"];
            string pageSize = string.IsNullOrWhiteSpace(Request["pageSize"]) ? "20" : Request["pageSize"];
            List<MeunDto> Meunlist = new List<MeunDto>();
            var Meun = (await _iMeunService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet
            int totaldata = Meun.Count();
            Meunlist = Meun.Skip(int.Parse(pageNumber) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            var result = new { total = totaldata, rows = Meunlist };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}