using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using JPGZService.testmysqldb.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.testmysqldb.EntityCache
{
   public class PersonCache: EntityCache<Person, GetPersonNameDto>, IPersonCache, ITransientDependency
    {
        public PersonCache(ICacheManager cacheManager, IRepository<Person> repository)
        : base(cacheManager, repository)
        {

        }
    }
}
