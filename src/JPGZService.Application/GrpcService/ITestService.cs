using JPGZService.testmysqldb;
using MagicOnion;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.GrpcService
{
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
}
