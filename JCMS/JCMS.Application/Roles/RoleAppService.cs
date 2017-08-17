using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using JCMS.Authorization;
using JCMS.Authorization.Roles;
using JCMS.Authorization.Users;
using JCMS.Roles.Dto;
using Microsoft.AspNet.Identity;

namespace JCMS.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class RoleAppService : AsyncCrudAppService<Role, RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IRepository<Role> _roleRepository;

        public RoleAppService(
            IRepository<Role> repository,
            RoleManager roleManager,
            UserManager userManager,
            IRepository<User, long> userRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository)
            : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        //public override async Task<RoleDto> Create(CreateRoleDto input)
        //{
        //    CheckCreatePermission();

        //    var role = ObjectMapper.Map<Role>(input);

        //    CheckErrors(await _roleManager.CreateAsync(role));

        //    var grantedPermissions = PermissionManager
        //        .GetAllPermissions()
        //        .Where(p => input.Permissions.Contains(p.Name))
        //        .ToList();

        //    await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

        //    return MapToEntityDto(role);
        //}

        //public override async Task<RoleDto> Update(RoleDto input)
        //{
        //    CheckUpdatePermission();

        //    var role = await _roleManager.GetRoleByIdAsync(input.Id);

        //    ObjectMapper.Map(input, role);

        //    CheckErrors(await _roleManager.UpdateAsync(role));

        //    var grantedPermissions = PermissionManager
        //        .GetAllPermissions()
        //        .Where(p => input.Permissions.Contains(p.Name))
        //        .ToList();

        //    await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

        //    return MapToEntityDto(role);
        //}

        //public override async Task Delete(EntityDto<int> input)
        //{
        //    CheckDeletePermission();

        //    var role = await _roleManager.FindByIdAsync(input.Id);
        //    if (role.IsStatic)
        //    {
        //        throw new UserFriendlyException("CannotDeleteAStaticRole");
        //    }

        //    var users = await GetUsersInRoleAsync(role.Name);

        //    foreach (var user in users)
        //    {
        //        CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.Name));
        //    }

        //    CheckErrors(await _roleManager.DeleteAsync(role));
        //}

        private Task<List<long>> GetUsersInRoleAsync(string roleName)
        {
            var users = (from user in _userRepository.GetAll()
                         join userRole in _userRoleRepository.GetAll() on user.Id equals userRole.UserId
                         join role in _roleRepository.GetAll() on userRole.RoleId equals role.Id
                         where role.Name == roleName
                         select user.Id).Distinct().ToList();

            return Task.FromResult(users);
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionDto>(
                ObjectMapper.Map<List<PermissionDto>>(permissions)
            ));
        }

        protected override IQueryable<Role> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Permissions);
        }

        protected override Task<Role> GetEntityByIdAsync(int id)
        {
            var role = Repository.GetAllIncluding(x => x.Permissions).FirstOrDefault(x => x.Id == id);
            return Task.FromResult(role);
        }

        protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.DisplayName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <returns></returns>
        public List<RoleDto> GetAllList()
        {
            List<RoleDto> userlist = new List<RoleDto>();
            var data = from s in _roleRepository.GetAll()
                       select new RoleDto()
                       {
                           id = s.Id,
                           DisplayName = s.DisplayName,//描述
                           Name = s.Name,
                           IsStatic = s.IsStatic,//是否启用
                           CreationTime = s.CreationTime,
                       };
            return userlist = data.ToList();
        }

    }
}