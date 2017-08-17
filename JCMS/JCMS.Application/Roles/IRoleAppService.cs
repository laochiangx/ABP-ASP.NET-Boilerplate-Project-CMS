using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JCMS.Roles.Dto;
using System.Collections.Generic;

namespace JCMS.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
        List<RoleDto> GetAllList();
    }
}
