using MagicOnion;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.GrpcService
{
   public interface ITestService: IService<ITestService>
    {
        UnaryResult<string> GetTestData();
    }
}
