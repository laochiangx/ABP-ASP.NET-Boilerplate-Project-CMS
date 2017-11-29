using ABPCMS.HangFires;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWorkWorkerPxoxyModule.HangFires
{
    public class HangfireWorkerPxoxy : IBackgroudWorkerProxy
    {
        public HangfireWorkerPxoxy()
        {

        }
        private WorkerConfig Config { get; set; }


        public void Excete<T>(Action method, WorkerConfig config) where T : IBackgroundWorkerDo
        {
            Config = config;
            string workerId = config.WorkerId;
            string cron = Cron.MinuteInterval(config.IntervalSecond / 60);
           RecurringJob.AddOrUpdate<T>(config.WorkerId, (t) => t.DoWork(), cron, TimeZoneInfo.Local);
           RecurringJob.Trigger(config.WorkerId);
        }
    }
}
