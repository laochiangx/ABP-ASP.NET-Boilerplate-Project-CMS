using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.Quartz
{
    public interface IHelloDependency
    {
        int ExecutionCount { get; set; }
    }
}
