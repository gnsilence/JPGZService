using Abp.Dependency;
using Abp.RemoteEventBus;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.testmysqldb.EventHandlers
{
    /// <summary>
    /// OnlyHandleThisTopic(是否只处理当前主题下的数据),SuspendWhenException 当出现异常时阻止继续处理事件，
    /// </summary>
    [RemoteEventHandler(ForType = "Type_Test", ForTopic = "Topic_Test", OnlyHandleThisTopic = true, SuspendWhenException = true)]
    public class HandleRemoteEventData : IRemoteEventHandler, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public HandleRemoteEventData()
        {
            Logger = NullLogger.Instance;
        }
        public void HandleEvent(RemoteEventArgs eventArgs)
        {
            Console.WriteLine($"收到的数据为：{eventArgs.EventData.Data["playload"]}");
            Logger.Info($"收到的数据为：{eventArgs.EventData.Data["playload"]}");
        }
    }
}
