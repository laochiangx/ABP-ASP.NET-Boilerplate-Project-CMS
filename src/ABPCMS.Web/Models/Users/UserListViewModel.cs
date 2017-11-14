using System.Collections.Generic;
using ABPCMS.Roles.Dto;
using ABPCMS.Users.Dto;

namespace ABPCMS.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}