using MagicOnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.GrpcService
{
   public interface ITestService: IService<ITestService>
    {
        UnaryResult<string> GetTestData();

        UnaryResult<object> GetFirstPerson();
    }
}
