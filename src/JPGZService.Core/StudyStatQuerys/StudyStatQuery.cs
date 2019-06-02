using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.StudyStatQuerys
{
    [Table("tb_StudyStat_Query")]
   public  class StudyStatQuery:Entity
    {
        /// <summary>
        /// 学员ID
        /// </summary>
        public System.Nullable<int> StudentId { get; set; }
        /// <summary>
        /// 科目一理论学时汇总
        /// </summary>
        public System.Nullable<double> Subject1Theory { get; set; }
        /// <summary>
        /// 科目一学时汇总
        /// </summary>
        public System.Nullable<double> Subject1ToTalAmt { get; set; }
        /// <summary>
        /// 科目二学时汇总
        /// </summary>
        public System.Nullable<double> Subject2ToTalAmt { get; set; }
        /// <summary>
        /// 科目二理论学时汇总
        /// </summary>
        public System.Nullable<double> Subject2Theory { get; set; }
        /// <summary>
        /// 科目二模拟学时汇总
        /// </summary>
        public System.Nullable<double> Subject2Operate { get; set; }
        /// <summary>
        /// 科目二实操学时汇总
        /// </summary>
        public System.Nullable<double> Subject2Simulate { get; set; }
        /// <summary>
        /// 科目三学时汇总
        /// </summary>
        public System.Nullable<double> Subject3ToTalAmt { get; set; }
        /// <summary>
        /// 科目三理论学时汇总
        /// </summary>
        public System.Nullable<double> Subject3Theory { get; set; }
        /// <summary>
        /// 科目三模拟学时汇总
        /// </summary>
        public System.Nullable<double> Subject3Operate { get; set; }
        /// <summary>
        /// 科目三实操学时汇总
        /// </summary>
        public System.Nullable<double> Subject3Simulate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<int> BInNewApply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<double> Subject1_OnlineLearning { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<double> Subject2_OnlineLearning { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<double> Subject3_OnlineLearning { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<double> S3mileage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<DateTime> LastStudyTime { get; set; }
        /// <summary>
        /// 科目一理论学时汇总
        /// </summary>
        public System.Nullable<double> Subject4Theory { get; set; }
        /// <summary>
        /// 科目一学时汇总
        /// </summary>
        public System.Nullable<double> Subject4ToTalAmt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<double> Subject4_OnlineLearning { get; set; }
    }
}
