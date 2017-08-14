using Abp.Authorization;
using JCMS.Authorization.Roles;
using JCMS.Authorization.Users;

namespace JCMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
