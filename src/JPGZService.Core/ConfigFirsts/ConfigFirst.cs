using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.ConfigFirsts
{
    [Table("tb_ConfigFirst")]
    public class ConfigFirst : Entity
    {
        public int FirstID { get; set; }
        public string FirstName { get; set; }
        public string FirstMark { get; set; }
        public int UserID { get; set; }
        public System.DateTime? Ldate { get; set; }
        public bool? DeleteMark { get; set; }
    }
}
