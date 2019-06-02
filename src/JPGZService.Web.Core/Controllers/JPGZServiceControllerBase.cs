using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JPGZService.Controllers
{
    public abstract class JPGZServiceControllerBase: AbpController
    {
        protected JPGZServiceControllerBase()
        {
            LocalizationSourceName = JPGZServiceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
