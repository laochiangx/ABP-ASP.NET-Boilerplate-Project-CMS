using Abp.Dependency;
using Abp.Domain.Repositories;
using ABPCMS.Authorization.Users;
using ABPCMS.HangFires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastWorkWorkerPxoxyModule.HangFires
{

        /// <summary>
        /// 清理短信日志
        /// </summary>
        public class SmsWorker : BackgroundWorker<SmsWorker>, ISingletonDependency
        {
            private readonly IRepository<User, long> _smsLogRepository;
            public SmsWorker(IRepository<User, long> smsLogRepository, IBackgroudWorkerProxy workMiddleware) : base(workMiddleware, new WorkerConfig { IntervalSecond = 60, WorkerId = "smsworker" })
            {
                _smsLogRepository = smsLogRepository;
            }
            public override void DoWork()
            {
            _smsLogRepository.GetAll();
            }
        }

    internal class SmsSendLog : User
    {
        public bool IsOk { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
