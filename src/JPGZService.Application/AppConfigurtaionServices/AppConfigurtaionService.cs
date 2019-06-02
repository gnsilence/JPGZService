using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Microsoft.Extensions.Options;

namespace JPGZService.AppConfigurtaionServices
{
    public class AppConfigurtaionService:IApplicationService
    {
        private readonly IOptions<ApplicationConfiguration> _appConfiguration;
        public AppConfigurtaionService(IOptions<ApplicationConfiguration> appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public ApplicationConfiguration AppConfigurations
        {
            get
            {
                return _appConfiguration.Value;
            }
        }
    }
}
