using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JPGZService.Configuration.Dto;
using Microsoft.AspNetCore.Mvc;

namespace JPGZService.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JPGZServiceAppServiceBase, IConfigurationAppService
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
