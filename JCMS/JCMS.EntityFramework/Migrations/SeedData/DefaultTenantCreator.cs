using System.Linq;
using JCMS.EntityFramework;
using JCMS.MultiTenancy;

namespace JCMS.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly JCMSDbContext _context;

        public DefaultTenantCreator(JCMSDbContext context)
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
