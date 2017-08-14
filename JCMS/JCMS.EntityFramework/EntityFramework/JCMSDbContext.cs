using System.Data.Common;
using Abp.Zero.EntityFramework;
using JCMS.Authorization.Roles;
using JCMS.Authorization.Users;
using JCMS.MultiTenancy;

namespace JCMS.EntityFramework
{
    public class JCMSDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public JCMSDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in JCMSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of JCMSDbContext since ABP automatically handles it.
         */
        public JCMSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public JCMSDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public JCMSDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
