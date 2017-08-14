using JCMS.EntityFramework;
using EntityFramework.DynamicFilters;

namespace JCMS.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly JCMSDbContext _context;

        public InitialHostDbBuilder(JCMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
