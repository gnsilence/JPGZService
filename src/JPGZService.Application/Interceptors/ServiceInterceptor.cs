using Castle.Core.Logging;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JPGZService.Interceptors
{
    /// <summary>
    /// 拦截普通方法(由于通过接口调用所以拦截的方法必须为虚方法)
    /// </summary>
    public class ServiceInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }
        public ServiceInterceptor()
        {
            Logger = NullLogger.Instance;
        }
        public void Intercept(IInvocation invocation)
        {
            //Before method execution
            var type = invocation.TargetType;
            var parametersdic = new Dictionary<string, object>();
            var stopwatch = Stopwatch.StartNew();
            var args = invocation.Arguments;
            var info = invocation.Method.GetParameters();
            foreach (var item in info)
            {
                var name = item.Name;
                var value = args[item.Position];
                parametersdic.Add(name, value);
            }
            //Executing the actual method
            invocation.Proceed();
            //After method execution
            stopwatch.Stop();
            Logger.InfoFormat(
                "Interceptor: {0} executed in {1} milliseconds; Arguments is {2}",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000"),
                JsonConvert.SerializeObject(parametersdic)
                );
        }
    }
}
