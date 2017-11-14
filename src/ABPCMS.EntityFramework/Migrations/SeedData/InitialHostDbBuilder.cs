using ABPCMS.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ABPCMS.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ABPCMSDbContext _context;

        public InitialHostDbBuilder(ABPCMSDbContext context)
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
