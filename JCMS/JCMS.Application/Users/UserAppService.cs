using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using JCMS.Authorization;
using JCMS.Authorization.Roles;
using JCMS.Authorization.Users;
using JCMS.Roles.Dto;
using JCMS.Users.Dto;
using Microsoft.AspNet.Identity;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using System;

namespace JCMS.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserAppService(
            IRepository<User, long> repository, 
            UserManager userManager, 
            IRepository<Role> roleRepository, IRepository<User, long> userRepository,
            RoleManager roleManager)
            : base(repository)
        {
            _userManager = userManager;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        public override async Task<UserDto> Get(EntityDto<long> input)
        {
            var user = await base.Get(input);
            var userRoles = await _userManager.GetRolesAsync(user.Id);
            user.Roles = userRoles.Select(ur => ur).ToArray();
            return user;
        }

        //public override async Task<UserDto> Create(CreateUserDto input)
        //{
        //    CheckCreatePermission();

        //    var user = ObjectMapper.Map<User>(input);

        //    user.TenantId = AbpSession.TenantId;
        //    user.Password = new PasswordHasher().HashPassword(input.Password);
        //    user.IsEmailConfirmed = true;

        //    //Assign roles
        //    user.Roles = new Collection<UserRole>();
        //    foreach (var roleName in input.RoleNames)
        //    {
        //        var role = await _roleManager.GetRoleByNameAsync(roleName);
        //        user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, role.Id));
        //    }

        //    CheckErrors(await _userManager.CreateAsync(user));

        //    return MapToEntityDto(user);
        //}

        //public override async Task<UserDto> Update(UpdateUserDto input)
        //{
        //    CheckUpdatePermission();

        //    var user = await _userManager.GetUserByIdAsync(input.Id);

        //    MapToEntity(input, user);

        //    CheckErrors(await _userManager.UpdateAsync(user));

        //    if (input.RoleNames != null)
        //    {
        //        CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
        //    }

        //    return await Get(input);
        //}

        //public override async Task Delete(EntityDto<long> input)
        //{
        //    var user = await _userManager.GetUserByIdAsync(input.Id);
        //    await _userManager.DeleteAsync(user);
        //}

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            return user;
        }

        protected override void MapToEntity(UpdateUserDto input, User user)
        {
            ObjectMapper.Map(input, user);
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = Repository.GetAllIncluding(x => x.Roles).FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <returns></returns>
        public List<UserDto> GetAllList()
        {
            List<UserDto> userlist = new List<UserDto>();
            var data = from s in _userRepository.GetAll()
                       select new UserDto()
                       {
                           id = s.Id.ToString(),
                           UserName = s.UserName,
                           Surname = s.Surname,
                           EmailAddress = s.EmailAddress,
                           CreationTime = s.CreationTime,
                           Name = s.Name
                       };
            return userlist = data.ToList();
        }
    }
}