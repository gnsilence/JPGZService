using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace JPGZService.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TryLoadAssembly();
            BuildWebHost(args).Run();
        }

        private static void TryLoadAssembly()
        {
             Assembly entry = Assembly.GetEntryAssembly();
             //找到当前执行文件所在路径
             string dir = Path.GetDirectoryName(entry.Location);
             string entryName = entry.GetName().Name;
             //获取执行文件同一目录下的其他dll
             foreach (string dll in Directory.GetFiles(dir, "*.dll"))
             {
                 if (entryName.Equals(Path.GetFileNameWithoutExtension(dll))) { continue; }
                 //非程序集类型的关联load时会报错
                 try
                 {
                     AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
                 }
                 catch (Exception ex)
                 {
                 }
             }
         }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
