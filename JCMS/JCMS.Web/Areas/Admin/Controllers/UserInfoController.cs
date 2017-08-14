using Abp.Application.Services.Dto;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using JCmsErp.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JCmsErp.Web.Areas.Admin.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserService _iUsersService;

        public UserInfoController(IUserService iUsersService)
        {

            _iUsersService = iUsersService;

        }
        // GET: Admin/UserInfo
        public ActionResult Index()
        {
            return View();
        }

        [DisableAbpAntiForgeryTokenValidation]
        [HttpGet]
        [DontWrapResult] //不需要AbpJsonResult
        public JsonResult GetUsersList()
        {
            string pageNumber = string.IsNullOrWhiteSpace(Request["pageNumber"]) ? "0" : Request["pageNumber"];
            string pageSize = string.IsNullOrWhiteSpace(Request["pageSize"]) ? "20" : Request["pageSize"];
            List<UserInfoDto> Userlist = new List<UserInfoDto>();
            //   Task<ListResultDto<UserInfoDto>> user = _iUsersService.GetUsers();
            Userlist = _iUsersService.GetAllList();
            int totaldata = Userlist.Count();
            Userlist = Userlist.Skip(int.Parse(pageNumber) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            var result = new { total = totaldata, rows = Userlist };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var model = new UserInfoDto();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(UserInfoDto roleVm)
        {
            var result = _iUsersService.AddorUpdateUserList(roleVm);
            return Json(result);
        }
        [DisableAbpAntiForgeryTokenValidation]
        [HttpPost]
        [DontWrapResult]
        public ActionResult DelUserById(string Id)
        {
            var result = _iUsersService.DelUser(Id);
            return Json(result);
        }

    }
}