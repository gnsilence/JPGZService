using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Hangfire;
using Hangfire.HttpJob.Server;
using JPGZService.testmysqldb.Dto;
using JPGZService.testmysqldb.EntityCache;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Net.Mail;
using Abp.Configuration;
using JPGZService.AppConfigurtaionServices;
using JPGZService.SqlServertestModel;
using JPGZService.IRepositories;
using Abp.Domain.Uow;
using Abp.FreeSqlExtensions.FreeSqlExt.Repositories;
using Abp.RemoteEventBus;
using Microsoft.AspNetCore.Mvc;

namespace JPGZService.testmysqldb
{
    public class TestAppService : JPGZServiceAppServiceBase,ITestAppService
    {
        private readonly IRepository<Person> _personRepository;

        private readonly IRepository<Animal> _animalRepository;

        private readonly IFreeSqlRepository<News> _freeSqlRepository;

        private readonly IFreeSqlRepository<Person> _fpersonRepository;

        private readonly IFreeSqlRepository<Animal> _fanimalRepository;
        private readonly IRemoteEventBus _remoteEventBus;
        private readonly INewsRepository _newsrepository;
        /// <summary>
        /// 发送邮件
        /// </summary>
        private readonly IEmailSender _emailSender;
        //使用redis缓存
        private ICacheManager _cacheManager { get; set; }
        /// <summary>
        /// 使用实体缓存，通过automapper实现
        /// </summary>
        private readonly IPersonCache _personCache;
        /// <summary>
        /// 获取设置信息
        /// </summary>
        private readonly ISettingManager _settingManager;
        /// <summary>
        /// 获取配置文件信息
        /// </summary>
        private readonly AppConfigurtaionService _appConfigurtaionService;
        public TestAppService(
            IRepository<Person> personRepository,
            IRepository<Animal> animalRepository,
            ICacheManager cacheManager,
            IPersonCache personCache,
            IEmailSender emailSender,
            ISettingManager settingManager,
            AppConfigurtaionService appConfigurtaionService,
            INewsRepository newsrepository,
            IFreeSqlRepository<News> freeSqlRepository,
            IFreeSqlRepository<Person> fpersonRepository,
            IFreeSqlRepository<Animal> fanimalRepository,
            IRemoteEventBus remoteEventBus
        )
        {
            _personRepository = personRepository;
            _animalRepository = animalRepository;
            _cacheManager = cacheManager;
            _personCache = personCache;
            _emailSender = emailSender;
            _settingManager = settingManager;
            _appConfigurtaionService = appConfigurtaionService;
            _newsrepository = newsrepository;
            _freeSqlRepository = freeSqlRepository;
            _fpersonRepository = fpersonRepository;
            _fanimalRepository = fanimalRepository;
            _remoteEventBus = remoteEventBus;
        }
        /// <summary>
        /// 测试计划任务(httpjob)
        /// </summary>
        /// <param name="minutes">多少分钟后执行</param>
        public virtual void AddJobTest(int minutes)
        {
            // 获取配置信息方式一，通过配置管理器

            var deminutes = Convert.ToInt32(_settingManager.GetSettingValue("config.defaultMinutes"));

            //获取配置信息方式二，通过配置文件接口获取
            var deminutes2 = Convert.ToInt32(_appConfigurtaionService.AppConfigurations.defaultMinutes);

            var job = new HttpJobItem()
            {
                JobName = "PlanJob",
                QueueName = "apis",
                Method = "get",
                Url = "https://www.baidu.com",
                IsRetry = false,
                Corn = "",
                DelayFromMinutes = minutes > 0 ? minutes : deminutes
            };

            BackgroundJob.Schedule(() => HttpJob.Excute(job, job.JobName, job.QueueName, job.IsRetry, null), TimeSpan.FromMinutes(job.DelayFromMinutes));

        }
        /// <summary>
        /// 测试hangfire队列任务(httpjob)
        /// </summary>
        public void AddQueueJob()
        {
            BackgroundJob.Enqueue<TestAppService>(job => job.GetPeople());
        }
        /// <summary>
        /// 测试hangfire周期任务(httpjob)
        /// </summary>
        public void AddReJob()
        {
            var job = new HttpJobItem()
            {
                JobName = "ReJob",
                QueueName = "apis",
                Method = "get",
                Url = "https://www.baidu.com",
                IsRetry = false,
                Corn = "* * * * *",
                DelayFromMinutes = 0
            };

            RecurringJob.AddOrUpdate(job.JobName, () => Hangfire.HttpJob.Server.HttpJob.Excute(job, job.JobName, job.QueueName, job.IsRetry, null), job.Corn, TimeZoneInfo.Local);
        }

        /// <summary>
        /// 测试授权,基于identityserver4的授权和角色验证(需要为用户添加此角色才能访问方法,id4登录管理员端为用户分配角色权限)
        /// </summary>
        /// <returns>名称</returns>
        [Authorize(Roles = "superAdmin")]
        public virtual List<string> GetAnimals()
        {

            //_fanimalRepository.Delete(ainiaml);

            //_fanimalRepository.Delete(p=>p.Id==22);
            var animalnames = _fanimalRepository.GetAll().Select(p => p.Name).ToList();
            return animalnames;
        }
        /// <summary>
        /// 测试来自mysql库的查询
        /// </summary>
        /// <returns>名称</returns>
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
        /// <summary>
        /// 获取列表数据(使用redis缓存),支持任意格式，如果缓存中没有可以从自定义的数据源中查找，并放入缓存中
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPersonsByRedisCache()
        {
            return await _cacheManager
                .GetCache("mycache")
                .GetAsync("getallpersons", () => _personRepository.GetAllListAsync());
        }
        /// <summary>
        /// 通过id获取名称(使用EntityCache),支持通过id获取
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        public async Task<GetPersonNameDto> GetPersonNameByEntityCache(int id)
        {
            return await _personCache.GetAsync(id);
        }
        /// <summary>
        /// 使用emailsender发送邮件示例(需要授权和分配发送邮件的角色权限)
        /// </summary>
        [Authorize(Roles = "sendEmail,superAdmin")]
        public void SendEmail(EmalSendDto emalSendInput)
        {
            try
            {
                _emailSender.SendAsync
                    (
                    subject: emalSendInput.Subject,
                    to: emalSendInput.SendTo,
                    body: emalSendInput.Content,
                    isBodyHtml: true
                    );
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 测试freesql模块
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllNewsTitle()
        {
            //var list = _freeSqlRepository.Query<News>("").Select(p=>p.Ntitle).ToList();
            //var personlist = _fpersonRepository.GetAll().Select(p=>p.PersonName).ToList();
            var titleslist = _newsrepository.GetAll().Select(p => p.Ntitle).ToList();
            //var getentity = _newsrepository.Get(24);
            //getentity.Ncontent = "下雨了";
            ////使用sql语句查询结果，仅继承freesql可以使用
            //var sqlentity = _newsrepository.GetEntityBySql();
            //var entity = _newsrepository.Update(getentity);

            //测试postgresql

            //var postsqllist = _fanimalRepository.GetAll().Select(p => p.Name).ToList();
            return titleslist;
        }
        RemoteEventData EventData = new RemoteEventData("Type_Test");
        /// <summary>
        /// 测试分布式事件总线
        /// </summary>
        public void TestRemoteEventBus()
        {
            EventData = new RemoteEventData("Type_Test")
            {
                Data = { ["playload"] = DateTime.Now }
            };
            //事务执行成功时发送数据，否则不发送
            CurrentUnitOfWork.Completed += CurrentUnitOfWork_Completed;

            //测试出现异常的情况，
            //throw new Exception();
        }

        [ApiExplorerSettings(IgnoreApi = true)]//不在swagger显示此api
        [AutomaticRetry(Attempts =3,OnAttemptsExceeded =AttemptsExceededAction.Fail)]//重试次数，重试结果处理
        public void PublishData()
        {
            if (EventData != null)
            {
                _remoteEventBus.Publish("Topic_Test", EventData);
            }
        }
        private void CurrentUnitOfWork_Completed(object sender, EventArgs e)
        {
            //将事件添加到队列里面
            BackgroundJob.Enqueue<TestAppService>(job=>job.PublishData());
        }
    }
}
