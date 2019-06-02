using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.StudyStat_Student
{
    [Table("tb_StudyStat_Student")]
    public  class tb_StudyStat_Student:Entity
    {
        public System.Nullable<int> StudentId { get; set; }
        public System.Nullable<int> SubjectId { get; set; }
        public System.Nullable<double> RealTime { get; set; }
        public System.Nullable<double> ActualTime { get; set; }
        public System.Nullable<double> ValidActualTime { get; set; }
        public System.Nullable<double> InvalidActualTime { get; set; }
        public System.Nullable<double> StudyRate { get; set; }
        public System.Nullable<int> ValidStudyTimeExam { get; set; }
        /// <summary>
        /// 学习类型：1理论 2模拟 3实操
        /// </summary>
        public System.Nullable<int> StudyType { get; set; }
    }
}
