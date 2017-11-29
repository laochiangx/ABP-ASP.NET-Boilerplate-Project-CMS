using Abp.BackgroundJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangfireServiceBase
{
    public class MyService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public MyService(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }

        public void Test()
        {
            _backgroundJobManager.Enqueue<TestJob, int>(42);
        }
    }
}
