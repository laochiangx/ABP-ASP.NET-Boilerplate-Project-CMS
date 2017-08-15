using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using JCMS.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace JCMS.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<JCMS.EntityFramework.JCMSDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled =false;
            //AutomaticMigrationDataLossAllowed = false;
            ContextKey = "JCMS";
        }

        protected override void Seed(JCMS.EntityFramework.JCMSDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
