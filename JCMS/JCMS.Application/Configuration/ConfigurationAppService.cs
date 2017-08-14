using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JCMS.Configuration.Dto;

namespace JCMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JCMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
