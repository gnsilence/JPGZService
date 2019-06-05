using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.SqlServertestModel
{
    [Table("tb_News")]
    public class News : Entity
    {
        public int? Ntype { get; set; }
        public int? UserType { get; set; }
        public string Ntitle { get; set; }

        public string Ncontent { get; set; }

        public string Nattachment { get; set; }

        public string SysNattachment { get; set; }

        public int? UserID { get; set; }

        public DateTime? Cdate { get; set; }

        public Boolean? IsDelete { get; set; }

        public int? DataOrganizeID { get; set; }

        public int IsPublish { get; set; }

        public int? NewObject { get; set; }
        public string CoverPicture { get; set; }
        public bool? IsTopping { get; set; }
    }
}
