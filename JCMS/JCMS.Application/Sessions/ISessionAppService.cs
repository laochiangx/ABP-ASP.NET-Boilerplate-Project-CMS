using System.Threading.Tasks;
using Abp.Application.Services;
using JCMS.Sessions.Dto;

namespace JCMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
