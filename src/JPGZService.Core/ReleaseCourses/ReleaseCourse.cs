using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JPGZService.ReleaseCourses
{
    [Table("Tb_ReleaseCourse")]
    public class ReleaseCourse:Entity
    {
        public string CourseNo { get; set; }
        public System.Nullable<int> TeacherId { get; set; }
        public System.Nullable<DateTime> CourseDate { get; set; }
        public string CourseTimeSlot { get; set; }
        public System.Nullable<decimal> CoursePrice { get; set; }
        public System.Nullable<double> CourseDiscount { get; set; }
        public int SiteId { get; set; }
        public string VehicleNo { get; set; }
        public string DrivingType { get; set; }
        public System.Nullable<int> CourseType { get; set; }
        public string CourseContent { get; set; }
        public System.Nullable<DateTime> CreateDateTime { get; set; }
        public System.Nullable<bool> IsCancel { get; set; }
        public System.Nullable<int> HasAppointmentCount { get; set; }
        public System.Nullable<int> AppointmentCount { get; set; }
        public System.Nullable<DateTime> CourseBeginDateTime { get; set; }
        public System.Nullable<DateTime> CourseEndDateTime { get; set; }
        public System.Nullable<int> CourseStatus { get; set; }
        public System.Nullable<int> GPSID { get; set; }
        public string PracticeArea { get; set; }
    }
}
