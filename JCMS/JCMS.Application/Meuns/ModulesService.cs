using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JCms.Meuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace JCMS.Meuns
{
    public class ModulesService : AsyncCrudAppService<Meun, MeunDto, int, PagedResultRequestDto, MeunDto, MeunDto>, IModulesService
    {
        public ModulesService(IRepository<Meun, int> repository) : base(repository)
        {
        }
    }
}
