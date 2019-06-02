using Abp.Domain.Entities.Caching;
using JPGZService.testmysqldb.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.testmysqldb.EntityCache
{
  public  interface IPersonCache: IEntityCache<GetPersonNameDto>
    {
    }
}
