using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.SchoolSubjects
{
    [Table("tb_SchoolSubjects")]
    public class SchoolSubject:Entity
    {
        public System.Nullable<int> SubjectId { get; set; }
        public System.Nullable<int> DrivingType { get; set; }
        public int? MonitorTime { get; set; }
        public double? SyllabusTime { get; set; }
        public System.Nullable<double> StudyRate { get; set; }
        public System.Nullable<double> Numerical { get; set; }
        public System.Nullable<bool> DeleteMark { get; set; }
        /// <summary>
        /// 模拟大纲学时
        /// </summary>
        public System.Nullable<double> SyllabusTime_Simulate { get; set; }
        /// <summary>
        /// 模拟系数
        /// </summary>
        public System.Nullable<double> StudyRate_Simulate { get; set; }
        /// <summary>
        /// 理论大纲学时
        /// </summary>
        public System.Nullable<double> SyllabusTime_Theoretical { get; set; }
        /// <summary>
        /// 理论系数
        /// </summary>
        public System.Nullable<double> StudyRate_Theoretical { get; set; }
        /// <summary>
        /// 实操大纲学时
        /// </summary>
        public System.Nullable<double> SyllabusTime_Operate { get; set; }
        /// <summary>
        /// 实操系数
        /// </summary>
        public System.Nullable<double> StudyRate_Operate { get; set; }


        /// <summary>
        /// 大纲里程
        /// </summary>
        public double? SyllabusMil { get; set; }

        /// <summary>
        /// 最小学习时间
        /// </summary>
        public double? MinStudyTime { get; set; }

        /// <summary>
        /// 最小里程
        /// </summary>
        public double? MinMilage { get; set; }

        /// <summary>
        /// 最大学习时间
        /// </summary>
        public double? MaxStudyTime { get; set; }
    }
}
