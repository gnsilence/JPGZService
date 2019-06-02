using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.ConfigSeconds
{
    [Table("tb_ConfigSecond")]
    public class ConfigSecond:Entity
    {
        public int SecondID { get; set; }
        public int? FirstID { get; set; }
        public string SecondName { get; set; }
        public int UserID { get; set; }
        public System.DateTime? Ldate { get; set; }
        public int SecondOrder { get; set; }
        public bool? DeleteMark { get; set; }

        public string SecondMark { get; set; }
    }
}
