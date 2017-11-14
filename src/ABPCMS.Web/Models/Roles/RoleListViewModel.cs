using System.Collections.Generic;
using ABPCMS.Roles.Dto;

namespace ABPCMS.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}