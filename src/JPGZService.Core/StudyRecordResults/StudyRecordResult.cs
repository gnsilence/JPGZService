using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.StudyRecordResults
{
    [Table("tb_StudyRecord_Result")]
   public  class StudyRecordResult:Entity
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        // public int ID { get; set; }
        /// <summary>
        /// 学员Id
        /// </summary>
        public System.Nullable<int> StudentId { get; set; }
        /// <summary>
        /// 教练编号
        /// </summary>
        public System.Nullable<int> TeacherId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public System.Nullable<DateTime> BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public System.Nullable<DateTime> EndTime { get; set; }
        /// <summary>
        /// 实际学时
        /// </summary>
        public System.Nullable<double> RealTime { get; set; }
        /// <summary>
        /// 有效学时
        /// </summary>
        public System.Nullable<double> ActualTime { get; set; }
        /// <summary>
        /// 学时里程
        /// </summary>
        public System.Nullable<double> StudyMile { get; set; }
        /// <summary>
        /// 科目编号
        /// </summary>
        public System.Nullable<int> SubjectID { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public System.Nullable<DateTime> UploadTime { get; set; }
        /// <summary>
        /// 驾校编号
        /// </summary>
        public System.Nullable<int> DriveSchoolId { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public System.Nullable<int> GpsId { get; set; }
        /// <summary>
        /// 运算有效学时
        /// </summary>
        public System.Nullable<double> ValidActualTime { get; set; }
        /// <summary>
        /// 系数
        /// </summary>
        public System.Nullable<decimal> StudyRate { get; set; }
        /// <summary>
        /// 已统计：（1已分析，0未分析）
        /// </summary>
        public System.Nullable<int> HasStat { get; set; }
        /// <summary>
        /// 是否上传
        /// </summary>
        public System.Nullable<int> UploadFlag { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public System.Nullable<bool> DeleteMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> IsManual { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<int> ValidFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<int> MaxSpeed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<double> Mileage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> HasCalcMileage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<int> CalcFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<int> StudyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> ValidSpeed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> HasCalcVehStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> ValidVehStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> HasAnalysed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> HasCalcBlindspot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> ValidBlindspot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StudentCardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TecCardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DriveSchoolName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.Nullable<bool> UploadPhotos { get; set; }
         /// <summary>
        /// 上传状态  0:未上传1:已上传
        /// </summary>
         public System.Nullable<int> UploadStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Recnum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingPrograms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Stunum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Coachnum { get; set; }
    }
}
