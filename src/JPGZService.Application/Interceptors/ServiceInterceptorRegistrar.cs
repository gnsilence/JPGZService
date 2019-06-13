using Abp.Application.Services;
using Abp.Dependency;
using Castle.Core;
using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.Interceptors
{
    //注册拦截器
    public static class ServiceInterceptorRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ServiceInterceptor)));
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ServiceAsyncInterceptor)));
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ServiceWithPostAsyncActionInterceptor)));
            }
        }
    }
}
