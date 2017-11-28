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
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpZeroLdapModule), typeof(AbpAutoMapperModule), typeof(FastWorkWorkerPxoxyModule))]
    public class FastWorkCoreModule : AbpModule
    {
         
    }
}
