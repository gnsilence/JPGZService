using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.Configuration
{
    public class ConfigSettingProvider : SettingProvider
    {
        /// <summary>
        /// 设置邮件及其他配置信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                {
                   new SettingDefinition(EmailSettingNames.Smtp.Host, "smtp.qq.com", L("SmtpHost"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.Port, "465", L("SmtpPort"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.UserName, "592254126@qq.com", L("Username"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.Password, "hgbuxejwdwynbdcj", L("Password"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.Domain, "smtp.qq.com", L("DomainName"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.EnableSsl, "true", L("UseSSL"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.Smtp.UseDefaultCredentials, "false", L("UseDefaultCredentials"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.DefaultFromAddress, "592254126@qq.com", L("DefaultFromSenderEmailAddress"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                   new SettingDefinition(EmailSettingNames.DefaultFromDisplayName, "592254126@qq.com", L("DefaultFromSenderDisplayName"), scopes: SettingScopes.Application | SettingScopes.Tenant)
                };
        }
        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, JPGZServiceConsts.LocalizationSourceName);
        }
    }
}
