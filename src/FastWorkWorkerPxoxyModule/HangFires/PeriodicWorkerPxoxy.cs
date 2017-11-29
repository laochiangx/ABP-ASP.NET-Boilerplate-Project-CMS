using Abp.Threading.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFires
{
    public class PeriodicWorkerPxoxy : IBackgroudWorkerProxy
    {
        private Action ExetuteMethod { get; set; }
        protected readonly AbpTimer Timer;
        public PeriodicWorkerPxoxy(AbpTimer timer)
        {
            Timer = timer;
            Timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {

            }
        }

        public void Excete<T>(Action method, WorkerConfig config) where T : IBackgroundWorkerDo
        {
            ExetuteMethod = method;
            Timer.Period = config.IntervalSecond * 1000;//将传入的秒数转化为毫秒
            Timer.Start();
        }

        protected void DoWork()
        {
            ExetuteMethod();
        }
    }
}
