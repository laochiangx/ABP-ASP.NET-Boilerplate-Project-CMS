using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using JCMS.Authorization.Users;
using JCMS.Sessions.Dto;
using JCMS.Users;
using JCMS.Users.Dto;
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

        private readonly IUserAppService _UserAppService;

        public UserInfoController(

           IUserAppService UserAppService)
        {
            _UserAppService = UserAppService;
        }
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
            List<UserDto> Userlist = new List<UserDto>();
            Userlist = _UserAppService.GetAllList();
            int totaldata = Userlist.Count();
            Userlist = Userlist.Skip(int.Parse(pageNumber) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            var result = new { total = 10, rows = Userlist };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}