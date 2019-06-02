using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.Evaluations
{
    [Table("tb_Evaluation")]
   public  class Evaluation:Entity
    {
        public string StudentId { get; set; }
        public int Evalobject { get; set; }
        public int Type { get; set; }
        public int Overall { get; set; }
        public int Part { get; set; }
        public System.Nullable<DateTime> Evaluatetime { get; set; }
        public string Srvmanner { get; set; }
        public string Teachlevel { get; set; }
        public int? UploadStatus { get; set; }
    }
}
