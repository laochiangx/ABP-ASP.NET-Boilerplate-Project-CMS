using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.Quartz
{
  public  interface ISystemSchedulerService: IApplicationService
    {
        void StartScheduler();
    }
}
