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
using FastWorkWorkerPxoxyModule;
using FastWorkWorkerPxoxyModule.HangFires;
using ABPCMS.HangfireServiceBase;

namespace ABPCMS.Web
{
    [DependsOn(
        typeof(ABPCMSDataModule),
        typeof(ABPCMSApplicationModule),
        typeof(ABPCMSWebApiModule),
         typeof(AbpWebSignalRModule),   
        typeof(AbpWebMvcModule),
          typeof(AbpHangfireModule)
         // typeof(HangFireWorkerModule) //- ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
        )]

    public class ABPCMSWebModule : AbpModule
    {
        public override void PreInitialize()
        {
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
        }
    }

}
