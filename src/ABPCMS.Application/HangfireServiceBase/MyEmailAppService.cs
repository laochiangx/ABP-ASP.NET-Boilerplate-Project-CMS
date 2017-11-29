using Abp.Application.Services;
using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangfireServiceBase
{
    [AbpAuthorize]
    public class MyEmailAppService : ApplicationService, IMyEmailAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public MyEmailAppService(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }

        public async Task SendEmail(SendEmailInput input)
        {
            await _backgroundJobManager.EnqueueAsync<SimpleSendEmailJob, SimpleSendEmailJobArgs>(
            new SimpleSendEmailJobArgs
            {
                Subject = input.Subject,
                Body = input.Body,
                SenderUserId = AbpSession.GetUserId(),
                TargetUserId = input.TargetUserId
            });
        }
    }
}
