using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JCms.Meuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.Meuns
{
    public interface IModulesService : IAsyncCrudAppService<MeunDto, int, PagedResultRequestDto, MeunDto, MeunDto> // IApplicationService
    {

    }
}
