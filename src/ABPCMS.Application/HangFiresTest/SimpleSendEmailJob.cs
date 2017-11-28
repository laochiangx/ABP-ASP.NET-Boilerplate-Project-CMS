using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Net.Mail;
using ABPCMS.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.HangFiresTest
{
    public class SimpleSendEmailJob : BackgroundJob<SimpleSendEmailJobArgs>, ITransientDependency
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IEmailSender _emailSender;

        public SimpleSendEmailJob(IRepository<User, long> userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public override void Execute(SimpleSendEmailJobArgs args)
        {
            var senderUser = _userRepository.Get(args.SenderUserId);
            var targetUser = _userRepository.Get(args.TargetUserId);

            _emailSender.Send(senderUser.EmailAddress, targetUser.EmailAddress, args.Subject, args.Body);
        }
    }
}
