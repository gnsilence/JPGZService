using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.testmysqldb
{
    [Table("tb_Animal")]
    public class Animal: Entity
    {
        public string Name { get; set; }
        public Animal()
        {

        }
        public Animal(string name)
        {
            Name = name;
        }
    }
}
