using Abp.AutoMapper;
using Abp.Modules;
using Abp.Zero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWorkWorkerPxoxyModule
{
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpAutoMapperModule), typeof(FastWorkWorkerPxoxyModule))] //typeof(AbpZeroLdapModule)
    public class FastWorkCoreModule : AbpModule
    {
         
    }
}
