using Abp.Dependency;
using Abp.Modules;
using ABPCMS.HangFires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastWorkWorkerPxoxyModule
{
    public class FastWorkWorkerPxoxyModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        public override void PreInitialize()
        {
            IocManager.RegisterIfNot<IBackgroudWorkerProxy, PeriodicWorkerPxoxy>();
        }
    }
}
