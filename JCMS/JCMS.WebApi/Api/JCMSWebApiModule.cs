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
                .Build();

           Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

           // ConfigureSwaggerUi();
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

        //            var commentsFileName = "bin//JCMS.Application.xml";
        //            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
        //            //将注释的XML文档添加到SwaggerUI中
        //            c.IncludeXmlComments(commentsFile);

        //        })
        //      .EnableSwaggerUi(c => c.InjectJavaScript(Assembly.GetExecutingAssembly(), "JCMS.SwaggerUi.Scripts.Swagger.js"));

        //}

        //public override void PreInitialize()
        //{
        //    ////关闭跨站脚本攻击
        //    Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
        //}
    }
}
