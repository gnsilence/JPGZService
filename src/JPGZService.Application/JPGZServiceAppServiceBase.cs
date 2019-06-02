using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;

namespace JPGZService
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class JPGZServiceAppServiceBase : ApplicationService
    {

        protected JPGZServiceAppServiceBase()
        {
            LocalizationSourceName = JPGZServiceConsts.LocalizationSourceName;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
