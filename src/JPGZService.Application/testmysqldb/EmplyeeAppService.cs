using Abp.Domain.Repositories;
using Abp.FreeSqlExtensions.FreeSqlExt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPGZService.testmysqldb
{
  public  class EmplyeeAppService: JPGZServiceAppServiceBase
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IFreeSqlRepository<Person> _freeSqlpersonRepository;
        private readonly IFreeSqlRepository<Animal> _freeSqlanimalRepository;
        private readonly IRepository<Animal> _animalrepository;
        public EmplyeeAppService(IRepository<Person> personRepository, IFreeSqlRepository<Person> freeSqlpersonRepository,
            IFreeSqlRepository<Animal> freeSqlanimalRepository, IRepository<Animal> animalrepository)
        {
            _personRepository = personRepository;
            _freeSqlpersonRepository = freeSqlpersonRepository;
            _freeSqlanimalRepository = freeSqlanimalRepository;
            _animalrepository = animalrepository;
        }
        /// <summary>
        /// 测试接口
        /// </summary>
        public string  Get()
        {
            return _personRepository.FirstOrDefault(p=>p.PersonName!=null).PersonName;
        }
        /// <summary>
        /// 测试服务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Animal UpdateEntity(int id)
        {
            var entity = _freeSqlanimalRepository.Get(id);
            entity.Name = "狮子";
           var updateentity= _freeSqlanimalRepository.UpdateAndGetEntity(entity);
            return updateentity;
        }
    }
}
