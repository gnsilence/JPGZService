using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.Configuration
{
    public class ConfigSettingProvider : SettingProvider
    {
        private readonly IConfigurationRoot _appConfiguration;
        private readonly IHostingEnvironment _env;
        public ConfigSettingProvider(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        /// <summary>
        /// 设置邮件及其他配置信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                {
                   new SettingDefinition(EmailSettingNames.Smtp.Host, _appConfiguration["App:SMTP:Host"], L("SmtpHost"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.Port, _appConfiguration["App:SMTP:Port"], L("SmtpPort"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.UserName, _appConfiguration["App:SMTP:UserName"], L("Username"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.Password, _appConfiguration["App:SMTP:Password"], L("Password"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.Domain, _appConfiguration["App:SMTP:Domain"], L("DomainName"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.EnableSsl, _appConfiguration["App:SMTP:EnableSsl"], L("UseSSL"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.UseDefaultCredentials, _appConfiguration["App:SMTP:UseDefaultCredentials"], L("UseDefaultCredentials"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.DefaultFromAddress, _appConfiguration["App:SMTP:DefaultFromAddress"], L("DefaultFromSenderEmailAddress"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.DefaultFromDisplayName, _appConfiguration["App:SMTP:DefaultFromDisplayName"], L("DefaultFromSenderDisplayName"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   //其他设置
                   new SettingDefinition("config.defaultMinutes",_appConfiguration["ApplicationConfiguration:defaultMinutes"],scopes: SettingScopes.Application | SettingScopes.Tenant)
                };
        }
        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, JPGZServiceConsts.LocalizationSourceName);
        }
    }
}
