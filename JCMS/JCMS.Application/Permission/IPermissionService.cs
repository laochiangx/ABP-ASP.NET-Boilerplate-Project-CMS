using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.Permissionse
{
    //public interface IPermissionService : IAsyncCrudAppService<PermissionDto, int, PagedResultRequestDto, PermissionDto, PermissionDto>
    //{

    //}
    //public interface IPermissionService
    public interface IPermissionService : IApplicationService
    {
        List<PermissionDto> GetMeunList();
    }
}
