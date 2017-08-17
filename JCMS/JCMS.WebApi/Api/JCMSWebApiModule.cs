using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using System.Linq;
using System;
using System.IO;
using Swashbuckle.Application;

namespace JCMS.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(JCMSApplicationModule))]
    public class JCMSWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(JCMSApplicationModule).Assembly, "app")
                .WithConventionalVerbs()
                .Build();

           Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

        }

        public override void PreInitialize()
        {
            ////关闭跨站脚本攻击
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
        }
    }
}
