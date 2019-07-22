using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Quartz;
using Abp.Runtime.Caching;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using ABPCMS.Authorization;
using ABPCMS.Authorization.Roles;
using ABPCMS.Quartz;
using ABPCMS.Users;
using ABPCMS.Web.Models.Users;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ABPCMS.Web.Controllers
{
    public class UserInfoController : ABPCMSControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;
        //private readonly ICacheManager _cacheManager;
        private readonly IQuartzScheduleJobManager _jobManager;
        private IScheduler _scheduler;

        private readonly ISystemSchedulerService _iSystemSchedulerService;
        public UserInfoController(IUserAppService userAppService, RoleManager roleManager, ICacheManager cacheManager, IQuartzScheduleJobManager jobManager, ISystemSchedulerService iSystemSchedulerService)
        {
            _userAppService = userAppService;
            _roleManager = roleManager;
            //_cacheManager = cacheManager;
            _jobManager = jobManager;
            _iSystemSchedulerService = iSystemSchedulerService;
        }
        // [OutputCache(Duration = 1200, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [DontWrapResult]

        public async Task<ActionResult> GetUserInfo()
        {
           // _iSystemSchedulerService.StartScheduler();
           await ScheduleJob();
            //setCache();
            string pageNumber = string.IsNullOrWhiteSpace(Request["pageNumber"]) ? "0" : Request["pageNumber"];
            string pageSize = string.IsNullOrWhiteSpace(Request["pageSize"]) ? "20" : Request["pageSize"];
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items;
            var Userlist = users.Skip(int.Parse(pageNumber) * int.Parse(pageSize)).Take(int.Parse(pageSize)).ToList();
            int totaldata = Userlist.Count();
            var result = new { total = 10, rows = Userlist };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void setCache()
        {

            //_cacheManager.GetCache("ControllerCache").Clear();

            //var userList = _cacheManager.GetCache("ControllerCache").Get("AllUsers", () => _userAppService.GetAlluser());

            //_cacheManager.GetCache("ControllerCache").Set("AllUsers", _userAppService.GetAlluser());
        }


        public async Task<ActionResult> ScheduleJob()
        {
            await _jobManager.ScheduleAsync<MyLogJob>(
                job =>
                {
                    job.WithIdentity("MyLogJobIdentity", "MyGroup")
                        .WithDescription("A job to simply write logs.");
                },
                trigger =>
                {
                    trigger.StartNow()
                        .WithSimpleSchedule(schedule =>
                        {
                            schedule.RepeatForever()
                                .WithIntervalInSeconds(5)
                                .Build();
                        });
                });
            _jobManager.Start();
            return Content("OK, scheduled!");
        }


    }
}