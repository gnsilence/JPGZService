using System.Threading.Tasks;
using JPGZService.Configuration.Dto;

namespace JPGZService.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
