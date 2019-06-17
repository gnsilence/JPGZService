using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.testmysqldb
{
  public  class EmplyeeAppService: JPGZServiceAppServiceBase
    {
        private readonly IRepository<Person> _personRepository;
        public EmplyeeAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        /// <summary>
        /// 测试接口
        /// </summary>
        public string  Get()
        {
            return _personRepository.FirstOrDefault(p=>p.PersonName!=null).PersonName;
        }
    }
}
