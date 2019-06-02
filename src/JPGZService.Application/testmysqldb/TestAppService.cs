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

namespace JPGZService.testmysqldb
{
    public class TestAppService : JPGZServiceAppServiceBase, ITestAppService
    {
        private readonly IRepository<Person> _personRepository;

        private readonly IRepository<Animal> _animalRepository;

        private readonly IEmailSender _emailSender;
        //使用redis缓存
        private ICacheManager _cacheManager { get; set; }
        /// <summary>
        /// 使用实体缓存，通过automapper实现
        /// </summary>
        private readonly IPersonCache _personCache;

        private readonly ISettingManager _settingManager;
        public TestAppService(
            IRepository<Person> personRepository,
            IRepository<Animal> animalRepository,
            ICacheManager cacheManager,
            IPersonCache personCache,
            IEmailSender emailSender,
            ISettingManager settingManager
        )
        {
            _personRepository = personRepository;
            _animalRepository = animalRepository;
            _cacheManager = cacheManager;
            _personCache = personCache;
            _emailSender = emailSender;
            _settingManager = settingManager;
        }
        /// <summary>
        /// 测试计划任务(httpjob)
        /// </summary>
        /// <param name="minutes">多少分钟后执行</param>
        public void AddJobTest(int minutes)
        {
            var job = new Hangfire.HttpJob.Server.HttpJobItem()
            {
                JobName = "PlanJob",
                QueueName = "apis",
                Method = "get",
                Url = "https://www.baidu.com",
                IsRetry = false,
                Corn = "",
                DelayFromMinutes = minutes
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
            var job = new Hangfire.HttpJob.Server.HttpJobItem()
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
        /// 测试授权验证(identityserver4)数据来自postgresql
        /// </summary>
        /// <returns>名称</returns>
        [Authorize]
        public List<string> GetAnimals()
        {
            var animalnames = _animalRepository.GetAll().Select(p => p.Name).ToList();
            return animalnames;
        }
        /// <summary>
        /// 测试来自mysql库的查询
        /// </summary>
        /// <returns>名称</returns>
        public List<string> GetPeople()
        {
            var peopleNames = _personRepository.GetAllList().Select(p => p.PersonName).ToList();
            var ss = _settingManager.GetSettingValue("Abp.Net.Mail.Smtp.Host");
            try
            {
                
         _emailSender.SendAsync(
               subject:"22222222222222",
               to: "592254126@qq.com",
               body: "A new task is assigned for you: <b>{task.Title}</b>",
               isBodyHtml: true
               );
            }
            catch (Exception ex)
            {

                throw;
            }
            return peopleNames;
        }
        /// <summary>
        /// 获取列表数据(使用redis缓存),支持任意格式，如果缓存中没有可以从自定义的数据源中查找，并放入缓存中
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPersonsByRedisCache()
        {
            return await _cacheManager.GetCache("mycache").GetAsync("getallpersons", () => _personRepository.GetAllListAsync());
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
    }
}
