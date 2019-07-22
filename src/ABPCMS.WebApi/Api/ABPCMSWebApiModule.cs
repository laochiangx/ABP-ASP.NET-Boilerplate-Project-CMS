using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using System.Linq;
using System;
using System.IO;

namespace ABPCMS.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(ABPCMSApplicationModule))]
    public class ABPCMSWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(ABPCMSApplicationModule).Assembly, "app")
                .WithConventionalVerbs()
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

            //ConfigureSwaggerUi();
        }

        //private void ConfigureSwaggerUi()
        //{
        //    Configuration.Modules.AbpWebApi().HttpConfiguration
        //        .EnableSwagger(c =>
        //        {
        //            c.SingleApiVersion("v1", "API文档");
        //            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

        //            //将application层中的注释添加到SwaggerUI中
        //            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        //            var commentsFileName = "bin//ABP.CMS.Application.xml";
        //            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
        //            //将注释的XML文档添加到SwaggerUI中
        //            c.IncludeXmlComments(commentsFile);

        //        })
        //      .EnableSwaggerUi(c => c.InjectJavaScript(Assembly.GetExecutingAssembly(), " ABPCMS.SwaggerUI.Scripts.wagger.js"));

        //}
    }
}
