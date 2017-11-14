using System.Threading.Tasks;
using Abp.Application.Services;
using ABPCMS.Configuration.Dto;

namespace ABPCMS.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}