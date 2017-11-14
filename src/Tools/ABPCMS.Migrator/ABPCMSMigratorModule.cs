using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using ABPCMS.EntityFramework;

namespace ABPCMS.Migrator
{
    [DependsOn(typeof(ABPCMSDataModule))]
    public class ABPCMSMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ABPCMSDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}