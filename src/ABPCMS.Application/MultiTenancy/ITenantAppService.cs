using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPCMS.MultiTenancy.Dto;

namespace ABPCMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
