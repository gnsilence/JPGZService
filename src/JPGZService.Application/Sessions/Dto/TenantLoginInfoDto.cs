using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JPGZService.MultiTenancy;

namespace JPGZService.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
