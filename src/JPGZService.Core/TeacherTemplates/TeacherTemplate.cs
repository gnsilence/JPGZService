using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.TeacherTemplates
{
    [Table("tb_teacherTemplate")]
    public class TeacherTemplate : Entity
    {
        public int? AddType { get; set; }
        public int? DriveSchoolID { get; set; }
        public int? TeaOrGroupID { get; set; }
        public string TemplateName { get; set; }
        public int? IsPush { get; set; }
        public int? Isdefault { get; set; }
        public int? AppRange { get; set; }
        public int? PayPath { get; set; }
        public string CarType { get; set; }
        public int? SubjectID { get; set; }
        public int? DetailSubjectID { get; set; }
        public int? IntervalTime { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public int? CanAppCount { get; set; }
        public string ClassIDS { get; set; }
        public decimal? StandardPrice { get; set; }
        public int? SiteId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
