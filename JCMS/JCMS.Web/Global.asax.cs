using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using System.Data.Entity;
using JCMS.EntityFramework;

namespace JCMS.Web
{
    public class MvcApplication : AbpWebApplication<JCMSWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<JCMSDbContext>());
           // Database.SetInitializer<JCMSDbContext>(null);
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            base.Application_Start(sender, e);
        }
    }
}
