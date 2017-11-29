using System.Threading.Tasks;

namespace ABPCMS.HangfireServiceBase
{
    internal interface IMyEmailAppService
    {
        Task SendEmail(SendEmailInput input);
    }
}