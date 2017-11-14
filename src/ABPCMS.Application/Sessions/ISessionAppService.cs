using System.Threading.Tasks;
using Abp.Application.Services;
using ABPCMS.Sessions.Dto;

namespace ABPCMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
