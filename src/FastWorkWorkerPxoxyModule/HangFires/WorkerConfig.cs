using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFires
{
    /// <summary>
    /// 工作任务配置
    /// </summary>
    public class WorkerConfig
    {
        /// <summary>
        /// 轮询秒数
        /// </summary>
        public int IntervalSecond { get; set; }
        /// <summary>
        /// 工作唯一编号
        /// </summary>
        public string WorkerId { get; set; }
    }
}
