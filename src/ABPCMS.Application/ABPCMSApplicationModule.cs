using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using ABPCMS.Authorization.Roles;
using ABPCMS.Authorization.Users;
using ABPCMS.Roles.Dto;
using ABPCMS.Users.Dto;
using Abp.Threading.BackgroundWorkers;
using Abp.Runtime.Caching;
using Abp.Runtime.Caching.Redis;
using Abp.Hangfire;
using Abp.Quartz;
using ABPCMS.HangfireServiceBase;
using Quartz;
using Abp.Quartz.Configuration;

namespace ABPCMS
{
    [DependsOn(typeof(ABPCMSCoreModule), typeof(AbpAutoMapperModule),
                  typeof(AbpHangfireModule),
          // typeof(HangFireWorkerModule) //- ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
          //typeof(AbpRedisCacheModule),
        typeof(AbpQuartzModule)

        )]

    public class ABPCMSApplicationModule : AbpModule 
    {

        public override void PreInitialize()
        {
            base.PreInitialize();
            //IocManager.Register<ICacheManager, AbpRedisCacheManager>();
            //如果Redis在本机,并且使用的默认端口,下面的代码可以不要
            //Configuration.Modules.AbpRedisCacheModule().ConnectionStringKey = "KeyName";

            //Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            //{
            //    mapper.AddProfile<ScheduleProfile>();
            //});
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());


                //// 创建Job
                //IScheduler scheduler = Configuration.Modules.AbpQuartz().Scheduler;

                //var missionJob = scheduler.GetJobDetail(new JobKey("missionJob", "OfficeGroup"));
                //if (missionJob == null)
                //{
                //    missionJob = JobBuilder.Create<MissionJob>()
                //        .WithIdentity("missionJob", "OfficeGroup")
                //        .WithDescription("执行定时任务")
                //        .StoreDurably(true)
                //        .Build();

                //    scheduler.AddJob(missionJob, true);
                //}
            });
        }
        public override void PostInitialize()

        {
            //注册后台工作者标记消极用户
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
           //   workManager.Add(IocManager.Resolve<MakeInactiveUsersPassiveWorker>());
        }
    }
}
