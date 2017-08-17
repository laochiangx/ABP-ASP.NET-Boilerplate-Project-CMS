using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JCMS.Roles.Dto;
using JCMS.Users.Dto;
using System.Collections.Generic;

namespace JCMS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        List<UserDto> GetAllList();
        ///// <summary>
        ///// 创建用户
        ///// </summary>
        ///// <param name="userdto"></param>
        ///// <returns></returns>
        //bool CreateUser(CreateUserDto userdto);

        ///// <summary>
        ///// 删除用户
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //string DelUser(string id);
    }
}