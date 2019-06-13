using Castle.Core.Logging;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JPGZService.Interceptors
{
    /// <summary>
    /// 拦截异步方法(由于通过接口调用所以拦截的方法必须为虚方法)
    /// </summary>
    public class ServiceAsyncInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }

        public ServiceAsyncInterceptor()
        {
            Logger = NullLogger.Instance;
        }
        public void Intercept(IInvocation invocation)
        {
            if (IsAsyncMethod(invocation.Method))
            {
                InterceptAsync(invocation);
            }
            else
            {
                InterceptSync(invocation);
            }
        }
        private void InterceptAsync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Calling the actual method, but execution has not been finished yet
            invocation.Proceed();

            //We should wait for finishing of the method execution
            ((Task)invocation.ReturnValue)
                .ContinueWith(task =>
                {
                    //After method execution
                    stopwatch.Stop();
                    Logger.InfoFormat(
                        "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                        invocation.MethodInvocationTarget.Name,
                        stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                        );
                });
        }

        private void InterceptSync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

           var args= invocation.Arguments;
            //After method execution
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }

        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }
    }
}
