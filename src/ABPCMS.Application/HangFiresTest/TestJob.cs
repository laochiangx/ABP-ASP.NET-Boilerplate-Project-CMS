using Abp.BackgroundJobs;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFiresTest
{
    public class TestJob : BackgroundJob<int>, ITransientDependency
    {
        public override void Execute(int number)
        { 
            Logger.Debug(number.ToString());
        }
    }
}
