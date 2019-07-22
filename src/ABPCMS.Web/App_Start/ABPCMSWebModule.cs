using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using ABPCMS.Api;
using Castle.MicroKernel.Registration;
using Hangfire;
using Microsoft.Owin.Security;
using Abp.Threading.BackgroundWorkers;
using ABPCMS.HangfireServiceBase;
using Abp.Runtime.Caching.Redis;
using System;
using Abp.Quartz;
using ABPCMS.Quartz;
using System.Threading;
using Shouldly;

namespace ABPCMS.Web
{
    [DependsOn(
        typeof(ABPCMSDataModule),
        typeof(ABPCMSApplicationModule),
        typeof(ABPCMSWebApiModule),
         typeof(AbpWebSignalRModule),   
        typeof(AbpWebMvcModule),
          typeof(AbpHangfireModule),
          //typeof(AbpRedisCacheModule),
        typeof(AbpQuartzModule)
        )]

    public class ABPCMSWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            ////配置使用Redis缓存
            //Configuration.Caching.UseRedis();

            ////配置所有Cache的默认过期时间为2小时
            //Configuration.Caching.ConfigureAll(cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(2);
            //});

            ////配置指定的Cache过期时间为8分钟
            //Configuration.Caching.Configure("LoginUserCache", cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(8);
            //});


            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<ABPCMSNavigationProvider>();

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(
                Component
                    .For<IAuthenticationManager>()
                    .UsingFactoryMethod(() => HttpContext.Current.GetOwinContext().Authentication)
                    .LifestyleTransient()
            );

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.BackgroundJobs.UseHangfire(configuration => //Configure to use hangfire for background jobs.
            {
                configuration.GlobalConfiguration.UseSqlServerStorage("Default"); //Set database connection
            });


         

        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<MakeInactiveUsersPassiveWorker>());


            var helloDependency = IocManager.Resolve<IHelloDependency>();
        }
    }

}
