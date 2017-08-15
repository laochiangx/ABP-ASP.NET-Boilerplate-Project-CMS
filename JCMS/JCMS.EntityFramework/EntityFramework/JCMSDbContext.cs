using System.Data.Common;
using Abp.Zero.EntityFramework;
using JCMS.Authorization.Roles;
using JCMS.Authorization.Users;
using JCMS.MultiTenancy;
using System.Data.Entity;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration;
using JCms.Meuns;
using Abp.Auditing;
using JCMS.Meuns;

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

        public virtual IDbSet<Meun> Modules { get; set; }
        public JCMSDbContext()
            : base("Default")
        {
          //  Database.SetInitializer<JCMSDbContext>(new DropCreateDatabaseAlways<JCMSDbContext>());
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
        [DisableAuditing]
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("", "ABP");
            modelBuilder.Configurations.Add(new ModulesCfg());

            base.OnModelCreating(modelBuilder);
        }

        //[DisableAuditing]
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //移除复数表名
        //   // modelBuilder.Configurations.Add(new Meun);

        //    modelBuilder.Entity<Meun>().ToTable("[dbo].[Modules]");

        //}
       

        //[DisableAuditing]
        //public class DecimalPrecisionAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
        //{
        //    public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DecimalPrecisionAttribute attribute)
        //    {
        //        if (attribute.Precision < 1 || attribute.Precision > 38)
        //        {
        //            throw new InvalidOperationException("Precision must be between 1 and 38.");
        //        }

        //        if (attribute.Scale > attribute.Precision)
        //        {
        //            throw new InvalidOperationException("Scale must be between 0 and the Precision value.");
        //        }

        //        configuration.HasPrecision(attribute.Precision, attribute.Scale);
        //    }
        //}
        //[DisableAuditing]
        //// [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        //public sealed class DecimalPrecisionAttribute : System.Attribute
        //{
        //    public DecimalPrecisionAttribute(byte precision, byte scale)
        //    {
        //        Precision = precision;
        //        Scale = scale;
        //    }
        //    public byte Precision { get; set; }
        //    public byte Scale { get; set; }
        //}
    }
}
