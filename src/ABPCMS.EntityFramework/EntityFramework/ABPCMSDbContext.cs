using System.Data.Common;
using Abp.Zero.EntityFramework;
using ABPCMS.Authorization.Roles;
using ABPCMS.Authorization.Users;
using ABPCMS.MultiTenancy;

namespace ABPCMS.EntityFramework
{
    public class ABPCMSDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ABPCMSDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ABPCMSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ABPCMSDbContext since ABP automatically handles it.
         */
        public ABPCMSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ABPCMSDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public ABPCMSDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
