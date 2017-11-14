using System.Linq;
using ABPCMS.EntityFramework;
using ABPCMS.MultiTenancy;

namespace ABPCMS.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly ABPCMSDbContext _context;

        public DefaultTenantCreator(ABPCMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
