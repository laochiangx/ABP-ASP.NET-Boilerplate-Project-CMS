using Abp.Authorization;
using ABPCMS.Authorization.Roles;
using ABPCMS.Authorization.Users;

namespace ABPCMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
