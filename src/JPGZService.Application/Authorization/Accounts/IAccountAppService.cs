using System.Threading.Tasks;
using Abp.Application.Services;
using JPGZService.Authorization.Accounts.Dto;

namespace JPGZService.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
