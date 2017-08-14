using System.Threading.Tasks;
using Abp.Application.Services;
using JCMS.Configuration.Dto;

namespace JCMS.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}