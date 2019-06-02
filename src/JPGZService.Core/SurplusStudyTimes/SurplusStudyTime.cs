using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.SurplusStudyTimes
{
    [Table("tb_SurplusStudyTime")]
    public class SurplusStudyTime:Entity
    {
        public int? StudentId { get; set; }
        public double? Part1SUMHours { get; set; }
        public double? Part2SUMHours { get; set; }
        public double? Part3SUMHours { get; set; }
        public double? Part4SUMHours { get; set; }
        public double? Part1SurplusHours { get; set; }
        public double? Part2SurplusHours { get; set; }
        public double? Part3SurplusHours { get; set; }
        public double? Part4SurplusHours { get; set; }
    }
}
