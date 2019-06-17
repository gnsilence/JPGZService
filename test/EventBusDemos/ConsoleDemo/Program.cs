using Abp;
using Abp.RemoteEventBus;
using System;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = AbpBootstrapper.Create<TestRemoteEventBusModule>();

            bootstrapper.Initialize();

            var remoteEventBus = bootstrapper.IocManager.Resolve<IRemoteEventBus>();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    const string type = "Type_Test";
                    const string topic = "Topic_Test";
                    var eventDate = new RemoteEventData(type)
                    {
                        Data = { ["playload"] = DateTime.Now }
                    };
                    remoteEventBus.Publish(topic, eventDate);

                    Task.Delay(1000).Wait();
                }
            });

            Console.WriteLine("任意键退出");
            Console.ReadKey();
        }
    }
}
