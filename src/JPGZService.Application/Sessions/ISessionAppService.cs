using System.Threading.Tasks;
using Abp.Application.Services;
using JPGZService.Sessions.Dto;

namespace JPGZService.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
