using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.TeacherLeaves
{
    [Table("Tb_TeacherLeave")]
    public class TeacherLeave : Entity
    {
        public int? TeacherId { get; set; }
        public float? TimeToLeave { get; set; }
        public string LeaveCause { get; set; }

        public int? IsPushInfo { get; set; }

        public DateTime? CreateDate { get; set; }

        public string OperateMan { get; set; }
        public string LeaveCourseIds { get; set; }
    }
}
