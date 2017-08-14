using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using JCMS.EntityFramework;

namespace JCMS.Migrator
{
    [DependsOn(typeof(JCMSDataModule))]
    public class JCMSMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<JCMSDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}