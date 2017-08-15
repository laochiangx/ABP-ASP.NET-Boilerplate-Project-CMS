using Abp.Auditing;
using JCms.Meuns;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.Meuns
{
    [DisableAuditing]
    public class ModulesCfg: EntityTypeConfiguration<Meun>
    {
        public ModulesCfg()
        {
            ToTable("Modules");

        }
    }
}
