using JPGZService.testmysqldb.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JPGZService.testmysqldb
{
  public  interface ITestAppService
    {
        List<string> GetPeople();
        List<string> GetAnimals();

        void AddJobTest(int minutes);

        void AddReJob();

        void AddQueueJob();

        Task<List<Person>> GetPersonsByRedisCache();

        Task<GetPersonNameDto> GetPersonNameByEntityCache(int id);
    }
}
