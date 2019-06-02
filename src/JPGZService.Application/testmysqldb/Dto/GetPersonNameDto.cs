using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.testmysqldb.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class GetPersonNameDto
    {
        public string PersonName { get; set; }
    }
}
