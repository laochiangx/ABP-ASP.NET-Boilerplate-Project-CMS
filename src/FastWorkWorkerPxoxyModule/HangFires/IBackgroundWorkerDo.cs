using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFires
{
    /// <summary>
    /// 所有的后台工作者类都应实现该接口
    /// </summary>
    public interface IBackgroundWorkerDo
    {
        /// <summary>
        /// 执行具体的任务
        /// </summary>
        void DoWork();
    }
}
