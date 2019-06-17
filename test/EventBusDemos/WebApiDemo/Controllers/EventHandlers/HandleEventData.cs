using Abp.Dependency;
using Abp.RemoteEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Controllers.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    [RemoteEventHandler(ForType = "Type_Test", ForTopic = "Topic_Test")]
    public class HandleEventData : IRemoteEventHandler, ITransientDependency
    {
        public void HandleEvent(RemoteEventArgs eventArgs)
        {
            Console.WriteLine($"收到的数据为：{eventArgs.EventData.Data["playload"]}");
        }
    }
}
