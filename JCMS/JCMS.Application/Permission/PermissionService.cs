using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Castle.Core.Logging;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Authorization.Roles;
using Abp.AutoMapper;

namespace JCMS.Permissionse
{
    //public class PermissionService : AsyncCrudAppService<Permissions, PermissionDto, int, PagedResultRequestDto, PermissionDto, PermissionDto>, IPermissionService
    //{
    //    public PermissionService(IRepository<Permissions, int> repository) : base(repository)
    //    {
    //    }
    //}
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<RolePermissionSetting, long> _rolePermissionSettingRepository;
        public ILogger Logger { get; set; }
        public PermissionService(IRepository<RolePermissionSetting, long> irolePermissionSettingRepository)
        {
            Logger = NullLogger.Instance;
            _rolePermissionSettingRepository = irolePermissionSettingRepository;
        }
        public List<PermissionDto> GetMeunList()
        {

            List<PermissionDto> MeunList = new List<PermissionDto>();
            var meun = _rolePermissionSettingRepository.GetAllList();
            var dataList = from a in _rolePermissionSettingRepository.GetAllList()
                           select new PermissionDto()
                           {
                               id = a.Id.ToString(),
                               Name = a.Name,
                               CreationTime = a.CreationTime,
                           };
            MeunList = dataList.ToList();
            return MeunList.ToList();
           
        }
    }
}