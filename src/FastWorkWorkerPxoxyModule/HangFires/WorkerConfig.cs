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
  
        private int  _IntervalSecond;
        public int  IntervalSecond
        {
            get { return _IntervalSecond; }
            set { _IntervalSecond = value; }
        }

        /// <summary>
        /// 工作唯一编号
        /// </summary>
        private string _WorkerId;
        public string WorkerId
        {
            get { return _WorkerId; }
            set { _WorkerId = value; }
        }
    }
}
