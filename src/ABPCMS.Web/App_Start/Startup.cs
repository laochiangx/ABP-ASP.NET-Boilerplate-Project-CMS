using Abp.Owin;
using ABPCMS.Api.Controllers;
using ABPCMS.Web;
using Hangfire;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Http;
using Hangfire.MemoryStorage;
using Abp.Hangfire;
using ABPCMS.Web.App_Start;
using System;
using log4net.Repository.Hierarchy;
using FastWorkWorkerPxoxyModule.HangFires;
using System.Web.Services.Description;
using ABPCMS.Users;
using Abp.Application.Services.Dto;
using Abp.Threading.BackgroundWorkers;

[assembly: OwinStartup(typeof(Startup))]

namespace ABPCMS.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();

            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();



            //Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("Default");

            ////指定Hangfire使用内存存储后台任务信息
            //Hangfire.GlobalConfiguration.Configuration.UseMemoryStorage();
            ////启用HangfireServer这个中间件（它会自动释放）
            //app.UseHangfireServer();
            ////启用Hangfire的仪表盘（可以看到任务的状态，进度等信息）
            //app.UseHangfireDashboard();

            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() }
            //});

            var jobId = BackgroundJob.Schedule(
                () => Console.WriteLine("Delayed!"),
                TimeSpan.FromDays(7));


            RecurringJob.AddOrUpdate(
                        () => Console.WriteLine("Recurring!"),
                        Cron.Daily);

            BackgroundJob.ContinueWith(
                            jobId,
                            () => Console.WriteLine("Continuation!"));


            var jobId2 = BackgroundJob.Schedule(
                        () => Console.WriteLine("Delayed!"),
                        TimeSpan.FromDays(7));





            //  ENABLE TO USE HANGFIRE dashboard(Requires enabling Hangfire in ABPCMSWebModule)
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() } //You can remove this line to disable authorization
            //});


            //EntityDto<long> input = new EntityDto<long>();
            //input.Id = 1;
            //BackgroundJob.Enqueue<UserAppService>(x => x.Get(input));

            app.MapSignalR();

            app.UseHangfireDashboard();
        }


}
}