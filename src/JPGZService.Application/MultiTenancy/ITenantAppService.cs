using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JPGZService.MultiTenancy.Dto;

namespace JPGZService.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
