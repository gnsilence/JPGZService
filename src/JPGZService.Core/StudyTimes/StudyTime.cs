using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.StudyTimes
{
    [Table("V_StudyTime")]
    public class StudyTime : Entity
    {
        public int? StudentId { get; set; }
        public int? Part1SUMValidHours { get; set; }
        public int? Part2SUMValidHours { get; set; }
        public int? Part3SUMValidHours { get; set; }
        public int? Part4SUMValidHours { get; set; }
        public int? Part1SUMHours { get; set; }
        public int? Part2SUMHours { get; set; }
        public int? Part3SUMHours { get; set; }
        public int? Part4SUMHours { get; set; }
        public double? Part1SurplusHours { get; set; }
        public double? Part2SurplusHours { get; set; }
        public double? Part3SurplusHours { get; set; }
        public double? Part4SurplusHours { get; set; }
        public string IDCardNo { get; set; }
        public int? DriveType { get; set; }
        public string DriveTypeName { get; set; }
    }
}
