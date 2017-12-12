using Castle.Core.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.Quartz
{
    public class SystemSchedulerService : ISystemSchedulerService
    {
        private IScheduler _scheduler;
        public ILogger _Logger { get; set; }
        public SystemSchedulerService()
        {
            _Logger = NullLogger.Instance;
        }

        public void StopScheduler()
        {
            _scheduler.Shutdown();
        }

        public void StartScheduler()
        {
            try
            {

                //这里读取配置文件中的任务开始时间
                int hour = int.Parse(((NameValueCollection)ConfigurationManager.GetSection("JobList/Job"))["Hour"]);
                int minute = int.Parse(((NameValueCollection)ConfigurationManager.GetSection("JobList/Job"))["Minute"]);


                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();//内存调度
                _scheduler = schedulerFactory.GetScheduler();

                //创建一个Job来执行特定的任务
                IJobDetail myLogJob = new JobDetailImpl("myLogJob", typeof(MyLogJob));
                //创建并定义触发器的规则（每天执行一次时间为：时：分）
                //ITrigger trigger =
                //    TriggerBuilder.Create()
                //        .WithDailyTimeIntervalSchedule(
                //            a => a.WithIntervalInHours(24).OnEveryDay().StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute))).Build();
                ITrigger trigger =
                TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule(
                        a => a.WithIntervalInSeconds(10)).Build();

                _scheduler.Clear();
                //将创建好的任务和触发规则加入到Quartz中
                _scheduler.ScheduleJob(myLogJob, trigger);
                //开始
                _scheduler.Start();

            }
            catch (Exception ex)
            {
                _Logger.Info(ex.Message);
            }
        }

    }
}
