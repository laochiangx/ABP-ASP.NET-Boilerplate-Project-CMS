using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ABPCMS.Configuration.Dto;

namespace ABPCMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ABPCMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
