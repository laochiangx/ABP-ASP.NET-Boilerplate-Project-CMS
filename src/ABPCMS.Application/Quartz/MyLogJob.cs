using Abp.Application.Services;
using Abp.Dependency;
using Abp.Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Castle.Core.Logging;

namespace ABPCMS.Quartz
{
    public class MyLogJob : JobBase, ITransientDependency
    {
        public ILogger _Logger { get; set; }
        public MyLogJob()
        {
            _Logger = NullLogger.Instance;

        }

        public override void Execute(IJobExecutionContext context)
        {
            try
            {
                _Logger.Info("QuartzJob 任务开始运行");

                for (int i = 0; i < 10; i++)
                {
                    _Logger.InfoFormat("QuartzJob 正在运行{0}", i);
                }

                _Logger.Info("QuartzJob任务运行结束");
            }
            catch (Exception ex)
            {
                _Logger.Error("运行异常:"+ex.Message, ex);
            }

        }
    }
}
