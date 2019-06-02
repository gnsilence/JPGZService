using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.AppointmentDetails
{
    [Table("Tb_AppointmentDetail")]
   public  class AppointmentDetail:Entity
    {
        public string AppNo { get; set; }
        public string CourseNo { get; set; }
        public System.Nullable<int> StuID { get; set; }
        public System.Nullable<int> TeacherID { get; set; }
        public System.Nullable<int> CourseType { get; set; }
        public string DrivingType { get; set; }
        public System.Nullable<decimal> CoursePrice { get; set; }
        public System.Nullable<double> CourseDiscount { get; set; }
        public System.Nullable<decimal> PayMoney { get; set; }
        public System.Nullable<int> AppStatus { get; set; }
        public System.Nullable<int> ReviewStatus { get; set; }
        public System.Nullable<int> EvalStatus { get; set; }
        public System.Nullable<int> EvalClass { get; set; }
        public string EvalContent { get; set; }
        public System.Nullable<DateTime> EvalDateTime { get; set; }
        public System.Nullable<DateTime> CreateDateTime { get; set; }
        public string Remark { get; set; }
        public int? PayPath { get; set; }
        public System.Nullable<int> PayType { get; set; }
        public System.Nullable<int> IsCheckout { get; set; }
        public int? CourseID { get; set; }
        public int? VehicleLevel { get; set; }
        public int? CourseLevel { get; set; }

        public int? IsAbsenteeism { get; set; }
    }
}
