- [ 基于ABP的动态Webapi快速开发框架](#head1)
	- [ 框架介绍](#head2)
		- [ 1.基础配置及数据库迁移](#head3)
			- [ 1.配置数据库连接](#head4)
			- [ 2.数据库迁移](#head5)
		- [ 2.普通webapi接口开发及测试](#head6)
			- [ 快速开发一个接口](#head7)
		- [ 3.GRPC服务快速开发及测试](#head8)
			- [ 1.快速开发一个GRPC服务](#head12)
			- [ 2.在普通WebpApi中使用GRPC客户端访问服务](#head13)
			- [ 3.使用Swagger调试GRPC服务](#head14)
		- [ 4.使用identityServer4保护接口安全](#head9)
		- [ 5.如何使用分布式事件总线](#head10)
		- [ 6.数据缓存，邮件发送，定时任务等配置及使用](#head11)
# <span id="head1"> 基于ABP的动态Webapi快速开发框架</span>
**目录 (Table of Contents)**

[TOCM]

[TOC]
## <span id="head2"> 框架介绍</span>
------------
> 关于ABP这里不在做描述，可以访问官网(https://aspnetboilerplate.com)来查看。
此框架是在ABPZero的基础上删除了原有的部分功能如用户，多租户，权限等，用来专注于接口开发，实现轻量级快速开发。可用于单库或多库，目前添加了，mysql, sqlserver, postgresql

> 项目的主要功能：
- 使用EFCore+Freesql作为ORM，通过EFCore来迁移数据库，代码运行时自动生成仓储层，接口层，可以方便快速写业务代码。
- 添加了拦截器示例，基于Castle.DynamicProxy，使用它的好处是，拦截时可以获取方法的参数名称及值，以及动态改变参数，动态改变方法返回值类型等。
- 添加了GRPC服务，方便开发GRPC服务，GRPC支持Consul作为服务注册及发现，方便支持集群，以及示例中展示了，如何在.netcore 控制台，及传统webapi
中使用GRPC服务或者其他ABP的模块。
- 添加了分布式事件总线，需要结合redis，rabbitmq, Kafka等作为消息中间件，使用方式类似abp自带的事件总线。
- 使用identityserver4替换原有的JWT验证。
- 使用redis缓存和内存缓存作为数据缓存组件，在redis禁用或不可用时，会自动切换到内存缓存，数据如果在缓存中没有，会使用默认查询方法，取得结果后
加入缓存。EntityCache，实体缓存相对使用不方便，不推荐使用。
- 添加了Hangfire作业任务的集成，可以方便使用后台任务，以及将事件处理，方法，用hangfire的队列来处理。

------------

------------
### <span id="head3"> 1.基础配置及数据库迁移</span>
#### <span id="head4"> 1.配置数据库连接</span>
数据库的配置位于Web.Host下，Appsetiings.json中
> 具体配置：
连接字符串：

```C#
"ConnectionStrings":{
"Default": "Data Source =.;Initial Catalog =XA_JPGZPlatform;User Id =sa;Password=123456;Trusted_Connection=False;Persist Security Info=true",
"Mysql": "Server=47.105.185.242;Port=3306;Database=jpmysql;Uid=root;Pwd=123456;charset=utf8;SslMode=none;Persist Security Info=true",
"PostgreSql": "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=abpapi;Persist Security Info=true"
}
```

> 分别为：sqlserver, mysql，postgresql的数据库配置,(`特别注意，如果使用freesql拓展，后面必须要配置Persist Security Info=true`)，因为freesql会从DBContext
获取连接字符串。

> 设置EFCore模块，多库及单库配置
在JPGZService.EntityFrameworkCore下，EntityFrameworkCore中的JPGZServiceEntityFrameworkModule中：
```C#
public bool SkipDbContextRegistration { get; set; }
// SkipRegister SqlserverContext
///跳过sqlserver注册
public bool SkipSqlserverDbContextRegistration { get; set; } = false;
/// <summary>
/// SkipRegister MysqlContext
/// </summary>
public bool SkipMysqlDbContextRegistration { get; set; } = false;
/// <summary>
/// Skip postSqlContext
/// </summary>
public bool SkipPostgreSqlDbContextRegistration { get; set; } = false;
/// <summary>
/// skip seed initdata
/// </summary>
public bool SkipDbSeed { get; set; }
```

分别为，是否跳过数据库注册，如果设置false则使用多库。
#### <span id="head5"> 2.数据库迁移</span>
使用codefirst使，先创建实体，项目中约定在领域层(JPGZService.Core)中创建实体文件，
格式如：
```C#
[Table("tb_Animal")]//表名
public class Animal: Entity
{
public string Name { get; set; }
public Animal()
{
}
public Animal(string name)
{
	Name = name;
}
}
```

然后别忘记在DBContext中添加DbSet.具体使用哪个库，在哪个库的context下添加
数据库迁移：
以mysql为例，需要执行的迁移命令：

```C#
Add-Migration _MysqlInit_201906 - Context JPGZServiceMysqlDbContext
```

```C#
Update-Database - Context JPGZServiceMysqlDbContext
```

如果迁移失败，删除项目中以及存在的迁移记录，然后再尝试生成数据库及表。

### <span id="head6"> 2.普通webapi接口开发及测试</span>
#### <span id="head7"> 快速开发一个接口</span>
> 项目中，接口开发统一放在(JPGZService.Application)模块下，ABP使用约定大于配置的方式，因此接口被限制为必须以 IXXXAppService
实现必须为 XXXAppService，其中APP可以改为别的名称，但是我们可以通过配置路由，无需更改，项目中已经配置了路由，格式为：
api/{action.Controller.ControllerName}/{action.ActionName}
符合普通api的使用习惯，支持通过谓词，设置方法为Post，或者Get等。

开发一个示例接口只需要执行以下步骤：
1. 添加一个接口，IxxxAppService,添加一个实现XXXAppservice继承于IxxxAppService
2. XXXAppservice中的实现
```C#
public class TestAppService : JPGZServiceAppServiceBase
{
private readonly IRepository<Person> _personRepository;
	public TestAppService(IRepository<Person> personRepository)
	{
		_personRepository = personRepository;
	}
	public List<string> GetPeople()
	{
		var entity = new Person()
		{
			PersonName = "张锋"
		};
		var eny = _fpersonRepository.InsertAndGetEntityAsync(entity);
		var peopleNames = _fpersonRepository.GetAll().Select(p => p.PersonName).ToList();
		return peopleNames;
	}
}
```

这样就完成了一个接口的开发，仓储通过动态生成，无需手动添加，Abp中的所有方法都自带事务操作。
(`特别的：可以省略接口层，直接添加XXXAppService，无需添加IXXXAppService,因为继承的基类继承了ApplicationService，这样写开发速度快，但是有时候不利于维护`)

使用Freesql作为Orm，仅仅只需要将IRepository写为IFreeSqlRepository，就可以实现如批量添加，批量更新，执行sql语句等功能。

`使用Swagger调试接口，只需要更改配置文件中，Swagger的值为Abp.api，设置为Grpc.Api是用来调试GRPC服务`

### <span id="head8"> 3.GRPC服务快速开发及测试</span>
#### <span id="head12"> 1. 快速开发一个GRPC服务
> 快速开发一个GRPC服务，服务存放位置和普通Api一样，不同的是接口定义，接口实现，及序列化
接口的定义如下：

```C#
 public interface ITestService: IService<ITestService>
    {
        /// <summary>
        /// grpc服务
        /// </summary>
        /// <returns></returns>
        UnaryResult<string> GetTestData();
        /// <summary>
        /// 获取查询出的第一个结果
        /// </summary>
        /// <returns></returns>
        UnaryResult<Person> GetFirstPerson();
    }
```
如果返回值类型是实体，则需要序列化，只需要添加如下特性：

```C#
	[MessagePackObject(true)]//序列化
    [Table("tb_Person")]
    public class Person:Entity
    {

        public virtual string PersonName { get; set; }

        public Person()
        {

        }

        public Person(string personName)
        {
            PersonName = personName;
        }
    }
```

> 服务的实现，和普通接口实现方式一样，不同的是继承基类，返回值不一样,代码如下(`使用swagger调试时需要添加无参的构造函数`)

```C#
 public class TestService : ServiceBase<ITestService>, ITestService
    {
        private readonly IRepository<Person> _personRepository;
        public TestService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public TestService()
        {

        }
        /// <summary>
        /// Grpc服务
        /// </summary>
        /// <returns></returns>
        public UnaryResult<string> GetTestData()
        {
            var personname = _personRepository.FirstOrDefault(p => p.PersonName != null).PersonName;
            return new UnaryResult<string>(personname);
        }

        public UnaryResult<Person> GetFirstPerson()
        {
            return new UnaryResult<Person>(_personRepository.FirstOrDefault(p => p.PersonName != null));
        }
    }
```

#### <span id="head13"> 2. 在普通WebpApi中使用GRPC客户端访问服务
> 使用Grpc客户端来调用服务，在普通的Core webApi中调用，可以添加一个简单的abp模块,引用AbpGrpcClientModule模块，来调用，例如：

```C#
[DependsOn(typeof(AbpGrpcClientModule))]
    public class TestAbpRemoteEventBusModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestAbpRemoteEventBusModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            // 配置grpc，直连模式
            Configuration.Modules.UseGrpcClientForDirectConnection(new[]
            {
                new GrpcServerNode
                {
                    GrpcServiceIp = "127.0.0.1",
                    GrpcServiceName = "TestServiceName",
                    GrpcServicePort = 40001
                }
            });
        }
    }
```

> 在启动类里面配置模块的启动：

```C#
 public static void Main(string[] args)
        {
            var bootstrapper = AbpBootstrapper.Create<TestAbpRemoteEventBusModule>();


            //bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f =>
            //   f.UseAbpLog4Net().WithConfig("log4net.config"));

            bootstrapper.Initialize();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
```

>最后配置依赖注入，将abp的依赖注入，转换成.net core自带的依赖注入:

```C#
services.AddSingleton(x =>
            {
                var connectionUtility= IocManager.Instance.IocContainer.Resolve<IGrpcConnectionUtility>();
                return connectionUtility;
            });
```

>在接口中使用
首先添加接口层

```C#
   public interface ITestService: IService<ITestService>
    {
        UnaryResult<string> GetTestData();

        UnaryResult<Person> GetFirstPerson();
    }
```
> 在接口层调用

```C#
private readonly IGrpcConnectionUtility _connectionUtility;

public ValuesController(IGrpcConnectionUtility connectionUtility)
{
    _connectionUtility = connectionUtility;
}

[HttpGet]
[Route("/api/GetGrpcService")]
public async Task<Person> GetGrpcService()
{
    var service = _connectionUtility.GetRemoteServiceForDirectConnection<ITestService>("TestServiceName");
    return await service.GetFirstPerson();
}
```
这样就可以方便的使用grpc服务，客户端如果不想创建实体类，可以将返回值改为object
#### <span id="head14"> 3. 使用Swagger调试GRPC服务
> 在配置文件中配置启用调试abp的api还是grpc服务，可以直接运行调试grpc。`需要注意的是，备注信息需要在接口层添加，和一般的不太一样。`
### <span id="head9"> 4.使用identityServer4保护接口安全</span>
### <span id="head10"> 5.如何使用分布式事件总线</span>
### <span id="head11"> 6.数据缓存，邮件发送，定时任务等配置及使用</span>
