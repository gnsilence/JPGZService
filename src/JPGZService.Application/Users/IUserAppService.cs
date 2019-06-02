using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JPGZService.Roles.Dto;
using JPGZService.Users.Dto;

namespace JPGZService.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
