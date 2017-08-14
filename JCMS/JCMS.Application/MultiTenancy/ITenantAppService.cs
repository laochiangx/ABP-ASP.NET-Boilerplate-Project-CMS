using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JCMS.MultiTenancy.Dto;

namespace JCMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
