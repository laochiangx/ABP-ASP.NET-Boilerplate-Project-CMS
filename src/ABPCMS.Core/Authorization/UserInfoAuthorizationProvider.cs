using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPCMS.Authorization
{
   public class UserInfoAuthorizationProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));

            //Tasks
            var tasks = pages.CreateChildPermission(PermissionNames.Pages_UserInfos, L("UserInfos"));
            tasks.CreateChildPermission(PermissionNames.Pages_UserInfos_Create, L("UserInfosCreate"));
            tasks.CreateChildPermission(PermissionNames.Pages_UserInfos_Delete, L("UserInfosDelete"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ABPCMSConsts.LocalizationSourceName);
        }
    }
}
