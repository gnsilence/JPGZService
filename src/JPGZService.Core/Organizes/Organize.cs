using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.Organizes
{
    [Table("tb_Organize")]
    public class Organize:Entity
    {
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Sort { get; set; }
        public bool? DeleteMark { get; set; }
        public bool Enabled { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }
        public int? CorrespondingId { get; set; }
        public int? levelNum { get; set; }
        public int? gpsid { get; set; }
    }
}
