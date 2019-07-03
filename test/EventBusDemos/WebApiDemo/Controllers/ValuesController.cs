using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Grpc.Client.Utility;
using Abp.RemoteEventBus;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.GrpcService;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRemoteEventBus _remoteEventBus;

        private readonly IGrpcConnectionUtility _connectionUtility;

        public ValuesController(IRemoteEventBus remoteEventBus, IGrpcConnectionUtility connectionUtility)
        {
            _remoteEventBus = remoteEventBus;
            _connectionUtility = connectionUtility;
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var EventData = new RemoteEventData("Type_Test")
            {
                Data = { ["playload"] = DateTime.Now }
            };
            //发布事件
            _remoteEventBus.Publish("Topic_Test", eventData: EventData);
            return "OK";
        }
        /// <summary>
        /// 测试grpc服务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetGrpcService")]
        public async Task<object> GetGrpcService()
        {
            var service = _connectionUtility.GetRemoteServiceForDirectConnection<ITestService>("TestServiceName");
            return await service.GetFirstPerson();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
