using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Abp.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace JPGZService.Web.Host.Startup
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var actionAttrs = context.ApiDescription.ActionAttributes();
            if (actionAttrs.OfType<AbpAllowAnonymousAttribute>().Any())
            {
                return;
            }

            var controllerAttrs = context.ApiDescription.ControllerAttributes();
            var actionAbpAuthorizeAttrs = actionAttrs.OfType<AuthorizeAttribute>();

            if (!actionAbpAuthorizeAttrs.Any() && controllerAttrs.OfType<AbpAllowAnonymousAttribute>().Any())
            {
                return;
            }

            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
             .Union(context.MethodInfo.GetCustomAttributes(true))
             .OfType<AuthorizeAttribute>().Any();

            //var controllerAbpAuthorizeAttrs = controllerAttrs.OfType<AuthorizeAttribute>();

            if (authAttributes)
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });
                //给api添加锁的标注
                operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                    new Dictionary<string, IEnumerable<string>> {{"oauth2", new[] {"apitest"}}}
                };
            }
            //if (controllerAbpAuthorizeAttrs.Any() || actionAbpAuthorizeAttrs.Any())
            //{
            //    operation.Responses.Add("401", new Response { Description = "Unauthorized" });

            //    //var permissions = controllerAbpAuthorizeAttrs.Union(actionAbpAuthorizeAttrs)
            //    //    .SelectMany(p => p.Permissions)
            //    //    .Distinct();

            //    //if (permissions.Any())
            //    //{
            //    //    operation.Responses.Add("403", new Response { Description = "Forbidden" });
            //    //}

            //    //operation.Security = new List<IDictionary<string, IEnumerable<string>>>
            //    //{
            //    //    new Dictionary<string, IEnumerable<string>>
            //    //    {
            //    //        { "bearerAuth", permissions }
            //    //    }
            //    //};
            //}
        }
    }
}
