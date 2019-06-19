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
    }
}
