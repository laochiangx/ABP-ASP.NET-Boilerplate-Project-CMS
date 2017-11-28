using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFires
{
    public interface IBackgroudWorkerProxy
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="method"></param>
        void Excete<T>(Action method, WorkerConfig config) where T : IBackgroundWorkerDo;
    }
}
