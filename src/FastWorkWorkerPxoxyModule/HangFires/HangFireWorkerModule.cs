using Abp.Dependency;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using ABPCMS.HangFires;
using FastWorkWorkerPxoxyModule.HangFires;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastWorkWorkerPxoxyModule
{
    public class HangFireWorkerModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        public override void PreInitialize()
        {
            IocManager.RegisterIfNot<IBackgroudWorkerProxy, HangfireWorkerPxoxy>();
        }
        public override void PostInitialize()
        {
            //判断是否启用了hangfire，如果启用了，则将IBackgroudWorkerProxy的实例改为hangfire
            var hangfireConfig = IocManager.Resolve<IAbpHangfireConfiguration>();
            if (hangfireConfig?.Server != null)
            {
             // IocManager.IocContainer.Register(Component.For<IBackgroudWorkerProxy>().ImplementedBy<HangfireWorkerPxoxy>().IsDefault());
            }
        }
    }
}
